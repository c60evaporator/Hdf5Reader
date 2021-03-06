﻿namespace HDF5Reader
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewDropHdf5 = new System.Windows.Forms.DataGridView();
            this.buttonOutputCsv = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewGroupDetail = new System.Windows.Forms.DataGridView();
            this.dataGridViewData = new System.Windows.Forms.DataGridView();
            this.labelDropHdf5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonSelectedGroupOnly = new System.Windows.Forms.RadioButton();
            this.radioButtonAllData = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonOutputAllData = new System.Windows.Forms.RadioButton();
            this.radioButtonOutputOnlyDisplayedData = new System.Windows.Forms.RadioButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButtonShiftJis = new System.Windows.Forms.RadioButton();
            this.radioButtonUtf8 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDropHdf5)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroupDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewDropHdf5
            // 
            this.dataGridViewDropHdf5.AllowDrop = true;
            this.dataGridViewDropHdf5.AllowUserToAddRows = false;
            this.dataGridViewDropHdf5.AllowUserToDeleteRows = false;
            this.dataGridViewDropHdf5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDropHdf5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDropHdf5.Location = new System.Drawing.Point(3, 29);
            this.dataGridViewDropHdf5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridViewDropHdf5.Name = "dataGridViewDropHdf5";
            this.dataGridViewDropHdf5.RowTemplate.Height = 24;
            this.dataGridViewDropHdf5.Size = new System.Drawing.Size(182, 272);
            this.dataGridViewDropHdf5.TabIndex = 0;
            this.dataGridViewDropHdf5.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDropHdf5_CellClick);
            this.dataGridViewDropHdf5.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridViewDropHdf5_DragDrop);
            this.dataGridViewDropHdf5.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridViewDropHdf5_DragEnter);
            // 
            // buttonOutputCsv
            // 
            this.buttonOutputCsv.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonOutputCsv.Location = new System.Drawing.Point(141, 23);
            this.buttonOutputCsv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonOutputCsv.Name = "buttonOutputCsv";
            this.buttonOutputCsv.Size = new System.Drawing.Size(84, 68);
            this.buttonOutputCsv.TabIndex = 1;
            this.buttonOutputCsv.Text = "出力";
            this.buttonOutputCsv.UseVisualStyleBackColor = true;
            this.buttonOutputCsv.Click += new System.EventHandler(this.buttonOutputCsv_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewDropHdf5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewGroupDetail, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewData, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelDropHdf5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(942, 433);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // dataGridViewGroupDetail
            // 
            this.dataGridViewGroupDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGroupDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewGroupDetail.Location = new System.Drawing.Point(191, 28);
            this.dataGridViewGroupDetail.Name = "dataGridViewGroupDetail";
            this.dataGridViewGroupDetail.RowTemplate.Height = 24;
            this.dataGridViewGroupDetail.Size = new System.Drawing.Size(323, 274);
            this.dataGridViewGroupDetail.TabIndex = 2;
            this.dataGridViewGroupDetail.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGroupDetail_CellDoubleClick);
            // 
            // dataGridViewData
            // 
            this.dataGridViewData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridViewData, 2);
            this.dataGridViewData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewData.Location = new System.Drawing.Point(520, 28);
            this.dataGridViewData.Name = "dataGridViewData";
            this.dataGridViewData.RowTemplate.Height = 24;
            this.dataGridViewData.Size = new System.Drawing.Size(419, 274);
            this.dataGridViewData.TabIndex = 3;
            // 
            // labelDropHdf5
            // 
            this.labelDropHdf5.AutoSize = true;
            this.labelDropHdf5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDropHdf5.Font = new System.Drawing.Font("Meiryo UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelDropHdf5.Location = new System.Drawing.Point(3, 0);
            this.labelDropHdf5.Name = "labelDropHdf5";
            this.labelDropHdf5.Size = new System.Drawing.Size(182, 25);
            this.labelDropHdf5.TabIndex = 4;
            this.labelDropHdf5.Text = "HDF5をDrag＆Dropして下さい";
            this.labelDropHdf5.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonSelectedGroupOnly);
            this.groupBox1.Controls.Add(this.radioButtonAllData);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(191, 308);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 94);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "表示法";
            // 
            // radioButtonSelectedGroupOnly
            // 
            this.radioButtonSelectedGroupOnly.AutoSize = true;
            this.radioButtonSelectedGroupOnly.Checked = true;
            this.radioButtonSelectedGroupOnly.Location = new System.Drawing.Point(6, 26);
            this.radioButtonSelectedGroupOnly.Name = "radioButtonSelectedGroupOnly";
            this.radioButtonSelectedGroupOnly.Size = new System.Drawing.Size(132, 23);
            this.radioButtonSelectedGroupOnly.TabIndex = 1;
            this.radioButtonSelectedGroupOnly.TabStop = true;
            this.radioButtonSelectedGroupOnly.Text = "選択グループのみ";
            this.radioButtonSelectedGroupOnly.UseVisualStyleBackColor = true;
            // 
            // radioButtonAllData
            // 
            this.radioButtonAllData.AutoSize = true;
            this.radioButtonAllData.Location = new System.Drawing.Point(6, 55);
            this.radioButtonAllData.Name = "radioButtonAllData";
            this.radioButtonAllData.Size = new System.Drawing.Size(79, 23);
            this.radioButtonAllData.TabIndex = 0;
            this.radioButtonAllData.Text = "全データ";
            this.radioButtonAllData.UseVisualStyleBackColor = true;
            this.radioButtonAllData.CheckedChanged += new System.EventHandler(this.radioButtonAllData_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(191, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "グループ内オブジェクト";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Location = new System.Drawing.Point(520, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "データ内容";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonOutputAllData);
            this.groupBox2.Controls.Add(this.radioButtonOutputOnlyDisplayedData);
            this.groupBox2.Controls.Add(this.buttonOutputCsv);
            this.groupBox2.Location = new System.Drawing.Point(708, 308);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(228, 94);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CSV出力";
            // 
            // radioButtonOutputAllData
            // 
            this.radioButtonOutputAllData.AutoSize = true;
            this.radioButtonOutputAllData.Checked = true;
            this.radioButtonOutputAllData.Location = new System.Drawing.Point(6, 55);
            this.radioButtonOutputAllData.Name = "radioButtonOutputAllData";
            this.radioButtonOutputAllData.Size = new System.Drawing.Size(79, 23);
            this.radioButtonOutputAllData.TabIndex = 3;
            this.radioButtonOutputAllData.TabStop = true;
            this.radioButtonOutputAllData.Text = "全データ";
            this.radioButtonOutputAllData.UseVisualStyleBackColor = true;
            // 
            // radioButtonOutputOnlyDisplayedData
            // 
            this.radioButtonOutputOnlyDisplayedData.AutoSize = true;
            this.radioButtonOutputOnlyDisplayedData.Location = new System.Drawing.Point(6, 26);
            this.radioButtonOutputOnlyDisplayedData.Name = "radioButtonOutputOnlyDisplayedData";
            this.radioButtonOutputOnlyDisplayedData.Size = new System.Drawing.Size(119, 23);
            this.radioButtonOutputOnlyDisplayedData.TabIndex = 2;
            this.radioButtonOutputOnlyDisplayedData.Text = "表示データのみ";
            this.radioButtonOutputOnlyDisplayedData.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 408);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(942, 25);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(25, 20);
            this.toolStripStatusLabel1.Text = "    ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButtonUtf8);
            this.groupBox3.Controls.Add(this.radioButtonShiftJis);
            this.groupBox3.Location = new System.Drawing.Point(520, 308);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(182, 94);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "エンコード";
            // 
            // radioButtonShiftJis
            // 
            this.radioButtonShiftJis.AutoSize = true;
            this.radioButtonShiftJis.Location = new System.Drawing.Point(6, 26);
            this.radioButtonShiftJis.Name = "radioButtonShiftJis";
            this.radioButtonShiftJis.Size = new System.Drawing.Size(93, 23);
            this.radioButtonShiftJis.TabIndex = 0;
            this.radioButtonShiftJis.Text = "Shift-JIS";
            this.radioButtonShiftJis.UseVisualStyleBackColor = true;
            // 
            // radioButtonUtf8
            // 
            this.radioButtonUtf8.AutoSize = true;
            this.radioButtonUtf8.Checked = true;
            this.radioButtonUtf8.Location = new System.Drawing.Point(6, 55);
            this.radioButtonUtf8.Name = "radioButtonUtf8";
            this.radioButtonUtf8.Size = new System.Drawing.Size(69, 23);
            this.radioButtonUtf8.TabIndex = 1;
            this.radioButtonUtf8.TabStop = true;
            this.radioButtonUtf8.Text = "UTF8";
            this.radioButtonUtf8.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 433);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "HDF5 Reader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDropHdf5)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroupDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDropHdf5;
        private System.Windows.Forms.Button buttonOutputCsv;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.DataGridView dataGridViewGroupDetail;
        private System.Windows.Forms.DataGridView dataGridViewData;
        private System.Windows.Forms.Label labelDropHdf5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonSelectedGroupOnly;
        private System.Windows.Forms.RadioButton radioButtonAllData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonOutputAllData;
        private System.Windows.Forms.RadioButton radioButtonOutputOnlyDisplayedData;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButtonUtf8;
        private System.Windows.Forms.RadioButton radioButtonShiftJis;
    }
}

