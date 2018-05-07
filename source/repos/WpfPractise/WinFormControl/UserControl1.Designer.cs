namespace WinFormControl
{
    partial class UserControl1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_all = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_NSearch = new System.Windows.Forms.Button();
            this.btn_ISearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.inp_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.inp_id = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_all
            // 
            this.btn_all.Location = new System.Drawing.Point(714, 119);
            this.btn_all.Name = "btn_all";
            this.btn_all.Size = new System.Drawing.Size(75, 23);
            this.btn_all.TabIndex = 23;
            this.btn_all.Text = "All";
            this.btn_all.UseVisualStyleBackColor = true;
            this.btn_all.Click += new System.EventHandler(this.btn_all_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 151);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(806, 410);
            this.dataGridView1.TabIndex = 22;
            // 
            // btn_NSearch
            // 
            this.btn_NSearch.Location = new System.Drawing.Point(459, 81);
            this.btn_NSearch.Name = "btn_NSearch";
            this.btn_NSearch.Size = new System.Drawing.Size(75, 23);
            this.btn_NSearch.TabIndex = 21;
            this.btn_NSearch.Text = "Search";
            this.btn_NSearch.UseVisualStyleBackColor = true;
            this.btn_NSearch.Click += new System.EventHandler(this.btn_NSearch_Click);
            // 
            // btn_ISearch
            // 
            this.btn_ISearch.Location = new System.Drawing.Point(459, 33);
            this.btn_ISearch.Name = "btn_ISearch";
            this.btn_ISearch.Size = new System.Drawing.Size(75, 23);
            this.btn_ISearch.TabIndex = 20;
            this.btn_ISearch.Text = "Search";
            this.btn_ISearch.UseVisualStyleBackColor = true;
            this.btn_ISearch.Click += new System.EventHandler(this.btn_ISearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Name";
            // 
            // inp_name
            // 
            this.inp_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inp_name.Location = new System.Drawing.Point(234, 78);
            this.inp_name.Name = "inp_name";
            this.inp_name.Size = new System.Drawing.Size(210, 26);
            this.inp_name.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(212, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Id";
            // 
            // inp_id
            // 
            this.inp_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inp_id.Location = new System.Drawing.Point(234, 33);
            this.inp_id.Name = "inp_id";
            this.inp_id.Size = new System.Drawing.Size(210, 26);
            this.inp_id.TabIndex = 16;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_all);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_NSearch);
            this.Controls.Add(this.btn_ISearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inp_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inp_id);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(1000, 1000);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_all;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_NSearch;
        private System.Windows.Forms.Button btn_ISearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inp_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inp_id;
    }
}
