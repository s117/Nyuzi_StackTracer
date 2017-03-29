using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nyuzi_StackTracer {

    public partial class StackTracer : Form {
        private const int THREAD_NUM = 4;

        private ListBox[] thread_stack_view_box;
        private CheckBox[] thread_log_filter;
        private bool[] thread_log_filter_status;

        private int default_width;
        private int default_height;
        private StackTracerController controller;

        public StackTracer() {
            InitializeComponent();
            thread_stack_view_box = new ListBox[4];
            thread_stack_view_box[0] = Thread0ViewBox;
            thread_stack_view_box[1] = Thread1ViewBox;
            thread_stack_view_box[2] = Thread2ViewBox;
            thread_stack_view_box[3] = Thread3ViewBox;
            thread_log_filter = new CheckBox[4];
            thread_log_filter[0] = ThFilter0;
            thread_log_filter[1] = ThFilter1;
            thread_log_filter[2] = ThFilter2;
            thread_log_filter[3] = ThFilter3;
            thread_log_filter_status = new bool[4];


            default_height = this.Height;
            default_width = this.Width;
            controller = new StackTracerController(this);
        }



        public int GetThreadNum() { return THREAD_NUM; }


        delegate void DelegateUpdateDetailsOutput(string content);
        public void UpdateDetailsOutput(string content) {
            if (this.InvokeRequired) {
                this.Invoke(new DelegateUpdateAnalyzeOutput(UpdateAnalyzeOutput),new object[] { content });
            } else {
                this.DetailsOutputBar.Text = content;
            }
        }

        delegate void DelegateUpdateAnalyzeOutput(string content);
        public void UpdateAnalyzeOutput(string content) {
            if (this.InvokeRequired) {
                this.Invoke(new DelegateUpdateAnalyzeOutput(UpdateAnalyzeOutput),new object[] { content });
            } else {
                this.AnalyzeLogOutput.Text = content;
            }
        }

        delegate void DelegatePathInfo(string log_path,string symtab_path);
        public void UpdatePathInfo(string log_path,string symtab_path) {
            if (this.InvokeRequired) {
                this.Invoke(new DelegatePathInfo(UpdatePathInfo),new object[] { log_path,symtab_path });
            } else {
                this.LogPathBox.Text = log_path;
                this.SymtabPathBox.Text = symtab_path;
            }
        }

        delegate void DelegateAddNewLineToListBox(ListBox target,object newline);
        private void AddNewLineToListBox(ListBox target,object newline) {
            if (this.InvokeRequired) {
                this.Invoke(new DelegateAddNewLineToListBox(AddNewLineToListBox),new object[] { target,newline });
            } else {
                int hzSize = (int) target.CreateGraphics().MeasureString(newline.ToString(),target.Font).Width;
                if (hzSize > target.HorizontalExtent)
                    target.HorizontalExtent = hzSize;

                bool scroll = false;
                if (target.TopIndex == target.Items.Count - (int) (target.Height / target.ItemHeight))
                    scroll = true;
                target.Items.Add(newline);
                if (scroll)
                    target.TopIndex = target.Items.Count - (int) (target.Height / target.ItemHeight) + 2;
            }
        }

        delegate void DelegateUpdateLogBoxItem(List<LogBoxItem> content);
        public void UpdateLogBoxItem(List<LogBoxItem> content) {
            if (this.InvokeRequired) {
                this.Invoke(new DelegateUpdateLogBoxItem(UpdateLogBoxItem),new object[] { content });
            } else {
                bool[] filter = GetLogFilterStatus();
                LogViewBox.Visible = false;

                LogViewBox.Items.Clear();
                LogViewBox.HorizontalExtent = 0;

                if (content != null) {
                    for (int i = 0; i < content.Count; ++i) {
                        if (filter[content[i].GetThreadID()]) {
                            AddNewLineToListBox(LogViewBox,content[i]);
                        }
                    }
                }

                LogViewBox.Visible = true;
            }
        }

        delegate void DelegateUpdateStackBoxItem(List<StackBoxItem>[] content_arr);
        public void UpdateStackBoxItem(List<StackBoxItem>[] content_arr) {
            if (this.InvokeRequired) {
                this.Invoke(new DelegateUpdateStackBoxItem(UpdateStackBoxItem),new object[] { content_arr });
            } else {
                for (int i = 0; i < THREAD_NUM; ++i) {
                    thread_stack_view_box[i].Visible = false;
                    thread_stack_view_box[i].Items.Clear();
                    thread_stack_view_box[i].HorizontalExtent = 0;
                    if (content_arr != null) {
                        for (int j = 0; j < content_arr[i].Count(); ++j) {
                            AddNewLineToListBox(thread_stack_view_box[i],content_arr[i][j]);
                        }
                    }
                }

                for (int i = 0; i < THREAD_NUM; ++i) {
                    thread_stack_view_box[i].Visible = true;
                }
            }
        }



        private void ThreadView_DrawItem(object sender,DrawItemEventArgs e) {
            if (e.Index >= 0) {
                e.DrawBackground();
                Brush brush;
                if (((BoxItem) ((ListBox) sender).Items[e.Index]).GetCorrectness()) {
                    brush = Brushes.Black;
                } else {
                    brush = Brushes.Red;
                }

                e.DrawFocusRectangle();
                e.Graphics.DrawString(((ListBox) sender).Items[e.Index].ToString(),e.Font,brush,e.Bounds,StringFormat.GenericDefault);
            }
        }

        private void LogView_DrawItem(object sender,DrawItemEventArgs e) {
            if (e.Index >= 0) {
                e.DrawBackground();
                Brush brush;
                if (((BoxItem) ((ListBox) sender).Items[e.Index]).GetCorrectness()) {
                    brush = Brushes.Black;
                } else {
                    brush = Brushes.Red;
                }

                e.DrawFocusRectangle();
                e.Graphics.DrawString(((ListBox) sender).Items[e.Index].ToString(),e.Font,brush,e.Bounds,StringFormat.GenericDefault);
            }
        }


        private void LogViewBox_SelectedValueChanged(object sender,EventArgs e) {
            if (controller.GetLogLoadStatus()) {
                controller.RebuildStackTrace(((LogBoxItem) ((ListBox) sender).Items[((ListBox) sender).SelectedIndex]).Stack_record_idx);
                DetailsOutputBar.Text = ((BoxItem) ((ListBox) sender).Items[((ListBox) sender).SelectedIndex]).GetInfo();
            }
        }

        private void ThreadViewBox_SelectedIndexChanged(object sender,EventArgs e) {
            if (((ListBox) sender).SelectedIndex == -1)
                return;
            if (controller.GetLogLoadStatus()) {
                DetailsOutputBar.Text = ((BoxItem) ((ListBox) sender).Items[((ListBox) sender).SelectedIndex]).GetInfo();
            }
        }

        private void ThFilter_CheckedChanged(object sender,EventArgs e) {
            if (controller.GetLogLoadStatus()) {
                controller.FlushViewData(true);
            }
        }

        private void OpenLogBtn_Click(object sender,EventArgs e) {
            string symtab_file, log_file;

            OpenFileDialog dlg_open_log = new OpenFileDialog();
            dlg_open_log.Title = "Open log";
            dlg_open_log.Filter = "Nyuzi running log(*.log)|*.log";
            dlg_open_log.ValidateNames = true;
            dlg_open_log.CheckPathExists = true;
            dlg_open_log.CheckFileExists = true;
            if (dlg_open_log.ShowDialog() != DialogResult.OK) {
                return;
            }
            log_file = dlg_open_log.FileName;

            OpenFileDialog dlg_open_symtab = new OpenFileDialog();
            dlg_open_symtab.Title = "Open symbol table";
            dlg_open_symtab.Filter = "OBJDUMP symbol table output(*.sym)|*.sym";
            dlg_open_symtab.ValidateNames = true;
            dlg_open_symtab.CheckPathExists = true;
            dlg_open_symtab.CheckFileExists = true;
            if (dlg_open_symtab.ShowDialog() != DialogResult.OK) {
                symtab_file = null;
            } else {
                symtab_file = dlg_open_symtab.FileName;
            }

            controller.Load(symtab_file,log_file);
        }


        private void StackTracer_Resize(object sender,EventArgs e) {
            int delta_height = Height - default_height;
            int delta_width = Width - default_width;
        }
        public bool[] GetLogFilterStatus() {
            thread_log_filter_status[0] = thread_log_filter[0].Checked;
            thread_log_filter_status[1] = thread_log_filter[1].Checked;
            thread_log_filter_status[2] = thread_log_filter[2].Checked;
            thread_log_filter_status[3] = thread_log_filter[3].Checked;
            return thread_log_filter_status;
        }


        private void LogViewBox_SelectedIndexChanged(object sender,EventArgs e) {
            if (((ListBox) sender).SelectedIndex == -1)
                return;
            if (controller.GetLogLoadStatus()) {
                DetailsOutputBar.Text = ((BoxItem) ((ListBox) sender).Items[((ListBox) sender).SelectedIndex]).GetInfo();
                controller.RebuildStackTrace(((LogBoxItem) ((ListBox) sender).Items[((ListBox) sender).SelectedIndex]).Stack_record_idx);
            }
        }
    }
}
