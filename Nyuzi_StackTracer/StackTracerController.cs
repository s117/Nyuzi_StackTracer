using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyuzi_StackTracer {
    class StackTracerController {
        private class StackFrame {
            public UInt32 entry;
            public UInt32 return_address;
            public bool correctness;
        }

        private ObjdumpSymtabParser symtab_parser;
        private List<TraceRecord> log_records;

        StackTracer view;
        List<LogBoxItem> view_content_log_box;
        List<StackBoxItem>[] view_content_stack_box;
        string view_analyze_output;
        string view_content_log_file_name;
        string view_content_symtab_file_name;

        bool is_log_loaded;
        private int THREAD_NUM;

        public StackTracerController(StackTracer view) {
            this.view = view;
            symtab_parser = null;
            log_records = null;

            view_content_log_box = null;
            view_content_stack_box = null;

            view_analyze_output = "Load a trace log to start.";
            view_content_log_file_name = "None";
            view_content_symtab_file_name = "None";
            THREAD_NUM = view.GetThreadNum();
            is_log_loaded = false;
            FlushViewData(true);
        }

        private Stack<StackFrame>[] BuildStackTrace(List<TraceRecord> records_list,int build_to) {
            Stack<StackFrame>[] call_stack = new Stack<StackFrame>[THREAD_NUM];

            for (int i = 0; i < THREAD_NUM; ++i) {
                call_stack[i] = new Stack<StackFrame>();
            }

            for (int i = 0; i <= build_to; ++i) {
                TraceRecord item = records_list[i];

                if (!item.pc_valid || !item.target_valid) {
                    throw new NTracerException("Fail to build stack trace because the log No." + i + " contains error address.");
                }
                StackFrame frame;
                switch (item.type) {
                    case TraceRecord.inst_type_t.CALL:
                        frame = new StackFrame();
                        frame.entry = item.target;
                        frame.return_address = item.pc + 4;
                        if (call_stack[item.thread_id].Count() == 0) {
                            frame.correctness = true;
                        } else if ((call_stack[item.thread_id].Peek().correctness == true)) {
                            frame.correctness = true;
                        } else {
                            frame.correctness = false;
                        }
                        call_stack[item.thread_id].Push(frame);

                        break;
                    case TraceRecord.inst_type_t.RETURN:
                        int back_trace_cursor;
                        int back_trace_pos = -1;
                        for (back_trace_cursor = 0; back_trace_cursor < call_stack[item.thread_id].Count; ++back_trace_cursor) {
                            frame = call_stack[item.thread_id].ElementAt(back_trace_cursor);
                            if (item.target == frame.return_address) {
                                back_trace_pos = back_trace_cursor;
                                break;
                            }
                        }
                        if (back_trace_pos != -1) {
                            for (int j = 0; j <= back_trace_pos; ++j) {
                                call_stack[item.thread_id].Pop();
                            }
                        } else {
                            throw new NTracerException("Fail to build stack trace because the return address mismatch at log No." + i);
                        }

                        break;
                    default:
                        throw new NTracerException("Fatal internal error, records_list[" + i + "].type=" + records_list[i].type);
                }
            }

            return call_stack;
        }

        public bool Load(string symtab_file,string log_file) {
            try {
                symtab_parser = new ObjdumpSymtabParser(symtab_file);
                log_records = NyuziLogParser.Parse(log_file);

                view_content_log_box = GenerateLogViewContent(log_records);
                view_content_stack_box = null;
                view_content_log_file_name = log_file;
                view_content_symtab_file_name = symtab_file == null ? "Not load." : symtab_file;
                if (symtab_file == null) {
                    view_analyze_output = "Log \"" + log_file + "\" loaded without symbol table.";
                } else {
                    view_analyze_output = "Log \"" + log_file + "\" loaded with symbol table \"" + symtab_file + "\".";
                }
                is_log_loaded = true;
                FlushViewData(true);
                return true;
            } catch (NTracerException ex) {
                symtab_parser = null;
                view_content_log_box = null;
                view_content_stack_box = null;
                view_content_log_file_name = "None";
                view_content_symtab_file_name = "None";
                view_analyze_output = ex.GetReason();
                is_log_loaded = false;
                FlushViewData(true);
                return false;
            } catch (Exception ex) {
                symtab_parser = null;
                view_content_log_box = null;
                view_content_stack_box = null;
                view_content_log_file_name = "None";
                view_content_symtab_file_name = "None";
                view_analyze_output = ex.Message;
                is_log_loaded = false;
                FlushViewData(true);
                return false;
            }
        }


        private List<LogBoxItem> GenerateLogViewContent(List<TraceRecord> tr) {
            List<LogBoxItem> result = new List<LogBoxItem>(tr.Count);
            for (int i = 0; i < tr.Count; ++i) {
                result.Add(new LogBoxItem(tr,i,symtab_parser));
            }
            return result;
        }

        private List<StackBoxItem>[] GenerateStackViewContent(Stack<StackFrame>[] call_stack) {
            List<StackBoxItem>[] result = new List<StackBoxItem>[call_stack.Length];
            for (int i = 0; i < call_stack.Length; ++i) {
                result[i] = new List<StackBoxItem>();
            }
            for (int i = 0; i < call_stack.Length; ++i) {
                int export_num = call_stack[i].Count();
                for (int j = 0; j < export_num; ++j) {
                    StackFrame frame = call_stack[i].Pop();
                    StackBoxItem newitem = new StackBoxItem(frame.entry,frame.return_address,symtab_parser);
                    result[i].Add(newitem);
                }
            }

            return result;
        }



        public void FlushViewData(bool is_flush_log) {
            view.UpdateStackBoxItem(view_content_stack_box);
            if (is_flush_log) {
                view.UpdateLogBoxItem(view_content_log_box);
            }
            view.UpdateAnalyzeOutput(view_analyze_output);
            view.UpdatePathInfo(view_content_log_file_name,view_content_symtab_file_name);
            //SymTabFileLabel.Text = symtab_file;
            //NyuziLogFileLabel.Text = log_file;
        }

        public void RebuildStackTrace(int to_which_log) {
            if (!GetLogLoadStatus())
                return;

            try {
                UInt32 th_search_flag = 0;
                UInt32 all_thread_found = 0;
                for (int i = 0; i < THREAD_NUM; ++i) {
                    all_thread_found |= (UInt32) (1 << i);
                }


                Stack<StackFrame>[] call_stack = BuildStackTrace(log_records,to_which_log);
                view_content_stack_box = GenerateStackViewContent(call_stack);
                view_analyze_output = "Stack check pass.";

                StackBoxItem[] last_seen = new StackBoxItem[THREAD_NUM];
                for (int i = to_which_log; (i >= 0) && (th_search_flag != all_thread_found); --i) {
                    if ((th_search_flag & (1 << (int) log_records[i].thread_id)) == 0) {
                        last_seen[log_records[i].thread_id] = new StackBoxItem("> " + SymbolUtils.GenerateSymbolDisp(log_records[i].target,symtab_parser.QueryFuncSymByOffset(log_records[i].target)),
                            "Last seen position.",
                            call_stack[log_records[i].thread_id].Count == 0 ? true : call_stack[log_records[i].thread_id].Peek().correctness);
                        th_search_flag |= (UInt32) (1 << (int) log_records[i].thread_id);
                    }
                }

                for (int i = 0; i < THREAD_NUM; ++i) {
                    if ((th_search_flag & (1 << i)) == 0) {
                        last_seen[i] = new StackBoxItem("No record.",
                        "Last seen position.",
                        false);
                    }
                    view_content_stack_box[i].Insert(0,last_seen[i]);
                }

                FlushViewData(false);
            } catch (NTracerException ex) {
                view_analyze_output = ex.GetReason();
                FlushViewData(false);
            } catch (Exception ex) {
                view_analyze_output = ex.Message;
                FlushViewData(false);
            }
        }

        public bool GetLogLoadStatus() {
            return is_log_loaded;
        }
    }
}
