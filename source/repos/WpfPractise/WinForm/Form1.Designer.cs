namespace WinForm
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_NSearch = new System.Windows.Forms.Button();
            this.btn_ISearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.inp_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.inp_id = new System.Windows.Forms.TextBox();
            this.btn_all = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(53, 223);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(806, 410);
            this.dataGridView1.TabIndex = 14;
            // 
            // btn_NSearch
            // 
            this.btn_NSearch.Location = new System.Drawing.Point(496, 153);
            this.btn_NSearch.Name = "btn_NSearch";
            this.btn_NSearch.Size = new System.Drawing.Size(75, 23);
            this.btn_NSearch.TabIndex = 13;
            this.btn_NSearch.Text = "Search";
            this.btn_NSearch.UseVisualStyleBackColor = true;
            this.btn_NSearch.Click += new System.EventHandler(this.btn_NSearch_Click_1);
            // 
            // btn_ISearch
            // 
            this.btn_ISearch.Location = new System.Drawing.Point(496, 105);
            this.btn_ISearch.Name = "btn_ISearch";
            this.btn_ISearch.Size = new System.Drawing.Size(75, 23);
            this.btn_ISearch.TabIndex = 12;
            this.btn_ISearch.Text = "Search";
            this.btn_ISearch.UseVisualStyleBackColor = true;
            this.btn_ISearch.Click += new System.EventHandler(this.btn_ISearch_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Name";
            // 
            // inp_name
            // 
            this.inp_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inp_name.Location = new System.Drawing.Point(271, 150);
            this.inp_name.Name = "inp_name";
            this.inp_name.Size = new System.Drawing.Size(210, 26);
            this.inp_name.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(249, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Id";
            // 
            // inp_id
            // 
            this.inp_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inp_id.Location = new System.Drawing.Point(271, 105);
            this.inp_id.Name = "inp_id";
            this.inp_id.Size = new System.Drawing.Size(210, 26);
            this.inp_id.TabIndex = 8;
            // 
            // btn_all
            // 
            this.btn_all.Location = new System.Drawing.Point(751, 191);
            this.btn_all.Name = "btn_all";
            this.btn_all.Size = new System.Drawing.Size(75, 23);
            this.btn_all.TabIndex = 15;
            this.btn_all.Text = "All";
            this.btn_all.UseVisualStyleBackColor = true;
            this.btn_all.Click += new System.EventHandler(this.btn_all_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 738);
            this.Controls.Add(this.btn_all);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_NSearch);
            this.Controls.Add(this.btn_ISearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inp_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inp_id);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_NSearch;
        private System.Windows.Forms.Button btn_ISearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inp_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inp_id;
        private System.Windows.Forms.Button btn_all;
    }
}

