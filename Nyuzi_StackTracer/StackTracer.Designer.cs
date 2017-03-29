namespace Nyuzi_StackTracer {
    partial class StackTracer {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.Thread0ViewBox = new System.Windows.Forms.ListBox();
            this.LogViewBox = new System.Windows.Forms.ListBox();
            this.Thread2ViewBox = new System.Windows.Forms.ListBox();
            this.Thread1ViewBox = new System.Windows.Forms.ListBox();
            this.Thread3ViewBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.OpenLogBtn = new System.Windows.Forms.Button();
            this.StackTraceViewerGroup = new System.Windows.Forms.GroupBox();
            this.SymtabPathBox = new System.Windows.Forms.TextBox();
            this.LogPathBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ThFilter3 = new System.Windows.Forms.CheckBox();
            this.ThFilter2 = new System.Windows.Forms.CheckBox();
            this.ThFilter1 = new System.Windows.Forms.CheckBox();
            this.ThFilter0 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.AnalyzeLogOutput = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.DetailsOutputBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.StackTraceViewerGroup.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Thread0ViewBox
            // 
            this.Thread0ViewBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Thread0ViewBox.FormattingEnabled = true;
            this.Thread0ViewBox.HorizontalScrollbar = true;
            this.Thread0ViewBox.ItemHeight = 12;
            this.Thread0ViewBox.Location = new System.Drawing.Point(15, 39);
            this.Thread0ViewBox.Name = "Thread0ViewBox";
            this.Thread0ViewBox.Size = new System.Drawing.Size(254, 148);
            this.Thread0ViewBox.TabIndex = 0;
            this.Thread0ViewBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ThreadView_DrawItem);
            this.Thread0ViewBox.SelectedIndexChanged += new System.EventHandler(this.ThreadViewBox_SelectedIndexChanged);
            // 
            // LogViewBox
            // 
            this.LogViewBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.LogViewBox.FormattingEnabled = true;
            this.LogViewBox.HorizontalScrollbar = true;
            this.LogViewBox.ItemHeight = 12;
            this.LogViewBox.Location = new System.Drawing.Point(576, 39);
            this.LogViewBox.Name = "LogViewBox";
            this.LogViewBox.Size = new System.Drawing.Size(652, 328);
            this.LogViewBox.TabIndex = 4;
            this.LogViewBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.LogView_DrawItem);
            this.LogViewBox.SelectedIndexChanged += new System.EventHandler(this.LogViewBox_SelectedIndexChanged);
            // 
            // Thread2ViewBox
            // 
            this.Thread2ViewBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Thread2ViewBox.FormattingEnabled = true;
            this.Thread2ViewBox.HorizontalScrollbar = true;
            this.Thread2ViewBox.ItemHeight = 12;
            this.Thread2ViewBox.Location = new System.Drawing.Point(15, 219);
            this.Thread2ViewBox.Name = "Thread2ViewBox";
            this.Thread2ViewBox.Size = new System.Drawing.Size(254, 148);
            this.Thread2ViewBox.TabIndex = 5;
            this.Thread2ViewBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ThreadView_DrawItem);
            this.Thread2ViewBox.SelectedIndexChanged += new System.EventHandler(this.ThreadViewBox_SelectedIndexChanged);
            // 
            // Thread1ViewBox
            // 
            this.Thread1ViewBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Thread1ViewBox.FormattingEnabled = true;
            this.Thread1ViewBox.HorizontalScrollbar = true;
            this.Thread1ViewBox.ItemHeight = 12;
            this.Thread1ViewBox.Location = new System.Drawing.Point(308, 39);
            this.Thread1ViewBox.Name = "Thread1ViewBox";
            this.Thread1ViewBox.Size = new System.Drawing.Size(254, 148);
            this.Thread1ViewBox.TabIndex = 6;
            this.Thread1ViewBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ThreadView_DrawItem);
            this.Thread1ViewBox.SelectedIndexChanged += new System.EventHandler(this.ThreadViewBox_SelectedIndexChanged);
            // 
            // Thread3ViewBox
            // 
            this.Thread3ViewBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Thread3ViewBox.FormattingEnabled = true;
            this.Thread3ViewBox.HorizontalScrollbar = true;
            this.Thread3ViewBox.ItemHeight = 12;
            this.Thread3ViewBox.Location = new System.Drawing.Point(308, 219);
            this.Thread3ViewBox.Name = "Thread3ViewBox";
            this.Thread3ViewBox.Size = new System.Drawing.Size(254, 148);
            this.Thread3ViewBox.TabIndex = 7;
            this.Thread3ViewBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ThreadView_DrawItem);
            this.Thread3ViewBox.SelectedIndexChanged += new System.EventHandler(this.ThreadViewBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "Thread 0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(306, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "Thread 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(306, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "Thread 3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "Thread 2";
            // 
            // OpenLogBtn
            // 
            this.OpenLogBtn.Location = new System.Drawing.Point(967, 399);
            this.OpenLogBtn.Name = "OpenLogBtn";
            this.OpenLogBtn.Size = new System.Drawing.Size(261, 139);
            this.OpenLogBtn.TabIndex = 13;
            this.OpenLogBtn.Text = "OPEN LOG";
            this.OpenLogBtn.UseVisualStyleBackColor = true;
            this.OpenLogBtn.Click += new System.EventHandler(this.OpenLogBtn_Click);
            // 
            // StackTraceViewerGroup
            // 
            this.StackTraceViewerGroup.Controls.Add(this.SymtabPathBox);
            this.StackTraceViewerGroup.Controls.Add(this.LogPathBox);
            this.StackTraceViewerGroup.Controls.Add(this.label10);
            this.StackTraceViewerGroup.Controls.Add(this.label9);
            this.StackTraceViewerGroup.Controls.Add(this.label8);
            this.StackTraceViewerGroup.Controls.Add(this.ThFilter3);
            this.StackTraceViewerGroup.Controls.Add(this.ThFilter2);
            this.StackTraceViewerGroup.Controls.Add(this.ThFilter1);
            this.StackTraceViewerGroup.Controls.Add(this.ThFilter0);
            this.StackTraceViewerGroup.Controls.Add(this.label7);
            this.StackTraceViewerGroup.Controls.Add(this.AnalyzeLogOutput);
            this.StackTraceViewerGroup.Controls.Add(this.label6);
            this.StackTraceViewerGroup.Controls.Add(this.OpenLogBtn);
            this.StackTraceViewerGroup.Controls.Add(this.Thread3ViewBox);
            this.StackTraceViewerGroup.Controls.Add(this.Thread0ViewBox);
            this.StackTraceViewerGroup.Controls.Add(this.Thread2ViewBox);
            this.StackTraceViewerGroup.Controls.Add(this.label4);
            this.StackTraceViewerGroup.Controls.Add(this.LogViewBox);
            this.StackTraceViewerGroup.Controls.Add(this.Thread1ViewBox);
            this.StackTraceViewerGroup.Controls.Add(this.label3);
            this.StackTraceViewerGroup.Controls.Add(this.label1);
            this.StackTraceViewerGroup.Controls.Add(this.label2);
            this.StackTraceViewerGroup.Location = new System.Drawing.Point(15, 21);
            this.StackTraceViewerGroup.Name = "StackTraceViewerGroup";
            this.StackTraceViewerGroup.Size = new System.Drawing.Size(1234, 551);
            this.StackTraceViewerGroup.TabIndex = 14;
            this.StackTraceViewerGroup.TabStop = false;
            this.StackTraceViewerGroup.Text = "Stack Trace";
            // 
            // SymtabPathBox
            // 
            this.SymtabPathBox.Location = new System.Drawing.Point(108, 512);
            this.SymtabPathBox.Multiline = true;
            this.SymtabPathBox.Name = "SymtabPathBox";
            this.SymtabPathBox.ReadOnly = true;
            this.SymtabPathBox.Size = new System.Drawing.Size(853, 23);
            this.SymtabPathBox.TabIndex = 31;
            // 
            // LogPathBox
            // 
            this.LogPathBox.Location = new System.Drawing.Point(108, 485);
            this.LogPathBox.Multiline = true;
            this.LogPathBox.Name = "LogPathBox";
            this.LogPathBox.ReadOnly = true;
            this.LogPathBox.Size = new System.Drawing.Size(853, 23);
            this.LogPathBox.TabIndex = 30;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 517);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 12);
            this.label10.TabIndex = 26;
            this.label10.Text = "Symbol Table:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 490);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 25;
            this.label9.Text = "Nyuzi log:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1030, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 24;
            this.label8.Text = "Filter:";
            // 
            // ThFilter3
            // 
            this.ThFilter3.AutoSize = true;
            this.ThFilter3.Checked = true;
            this.ThFilter3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ThFilter3.Location = new System.Drawing.Point(1191, 17);
            this.ThFilter3.Name = "ThFilter3";
            this.ThFilter3.Size = new System.Drawing.Size(30, 16);
            this.ThFilter3.TabIndex = 23;
            this.ThFilter3.Text = "3";
            this.ThFilter3.UseVisualStyleBackColor = true;
            this.ThFilter3.CheckedChanged += new System.EventHandler(this.ThFilter_CheckedChanged);
            // 
            // ThFilter2
            // 
            this.ThFilter2.AutoSize = true;
            this.ThFilter2.Checked = true;
            this.ThFilter2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ThFilter2.Location = new System.Drawing.Point(1155, 17);
            this.ThFilter2.Name = "ThFilter2";
            this.ThFilter2.Size = new System.Drawing.Size(30, 16);
            this.ThFilter2.TabIndex = 22;
            this.ThFilter2.Text = "2";
            this.ThFilter2.UseVisualStyleBackColor = true;
            this.ThFilter2.CheckedChanged += new System.EventHandler(this.ThFilter_CheckedChanged);
            // 
            // ThFilter1
            // 
            this.ThFilter1.AutoSize = true;
            this.ThFilter1.Checked = true;
            this.ThFilter1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ThFilter1.Location = new System.Drawing.Point(1119, 17);
            this.ThFilter1.Name = "ThFilter1";
            this.ThFilter1.Size = new System.Drawing.Size(30, 16);
            this.ThFilter1.TabIndex = 21;
            this.ThFilter1.Text = "1";
            this.ThFilter1.UseVisualStyleBackColor = true;
            this.ThFilter1.CheckedChanged += new System.EventHandler(this.ThFilter_CheckedChanged);
            // 
            // ThFilter0
            // 
            this.ThFilter0.AutoSize = true;
            this.ThFilter0.Checked = true;
            this.ThFilter0.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ThFilter0.Location = new System.Drawing.Point(1083, 17);
            this.ThFilter0.Name = "ThFilter0";
            this.ThFilter0.Size = new System.Drawing.Size(30, 16);
            this.ThFilter0.TabIndex = 20;
            this.ThFilter0.Text = "0";
            this.ThFilter0.UseVisualStyleBackColor = true;
            this.ThFilter0.CheckedChanged += new System.EventHandler(this.ThFilter_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 384);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "Analyze output";
            // 
            // AnalyzeLogOutput
            // 
            this.AnalyzeLogOutput.Location = new System.Drawing.Point(15, 399);
            this.AnalyzeLogOutput.Multiline = true;
            this.AnalyzeLogOutput.Name = "AnalyzeLogOutput";
            this.AnalyzeLogOutput.ReadOnly = true;
            this.AnalyzeLogOutput.Size = new System.Drawing.Size(946, 82);
            this.AnalyzeLogOutput.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(574, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "Nyuzi Trace Log";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.DetailsOutputBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 591);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1261, 22);
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(50, 17);
            this.toolStripStatusLabel1.Text = "Details:";
            // 
            // DetailsOutputBar
            // 
            this.DetailsOutputBar.Name = "DetailsOutputBar";
            this.DetailsOutputBar.Size = new System.Drawing.Size(0, 17);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(619, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "Nyuzi Log";
            // 
            // StackTracer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 613);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.StackTraceViewerGroup);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StackTracer";
            this.Text = "Nyuzi Stack Tracer";
            this.Resize += new System.EventHandler(this.StackTracer_Resize);
            this.StackTraceViewerGroup.ResumeLayout(false);
            this.StackTraceViewerGroup.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Thread0ViewBox;
        private System.Windows.Forms.ListBox LogViewBox;
        private System.Windows.Forms.ListBox Thread2ViewBox;
        private System.Windows.Forms.ListBox Thread1ViewBox;
        private System.Windows.Forms.ListBox Thread3ViewBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button OpenLogBtn;
        private System.Windows.Forms.GroupBox StackTraceViewerGroup;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel DetailsOutputBar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox AnalyzeLogOutput;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox ThFilter3;
        private System.Windows.Forms.CheckBox ThFilter2;
        private System.Windows.Forms.CheckBox ThFilter1;
        private System.Windows.Forms.CheckBox ThFilter0;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox SymtabPathBox;
        private System.Windows.Forms.TextBox LogPathBox;
    }
}

