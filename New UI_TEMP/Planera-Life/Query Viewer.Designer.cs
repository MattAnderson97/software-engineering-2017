namespace Planera_Life
{
    partial class NewQueryDialogueBox
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
            this.txt_QueryText = new System.Windows.Forms.TextBox();
            this.txt_QueryTitle = new System.Windows.Forms.TextBox();
            this.btn_QueryCancel = new System.Windows.Forms.Button();
            this.btn_QuerySave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_QueryText
            // 
            this.txt_QueryText.Location = new System.Drawing.Point(12, 95);
            this.txt_QueryText.Multiline = true;
            this.txt_QueryText.Name = "txt_QueryText";
            this.txt_QueryText.Size = new System.Drawing.Size(354, 146);
            this.txt_QueryText.TabIndex = 0;
            // 
            // txt_QueryTitle
            // 
            this.txt_QueryTitle.Location = new System.Drawing.Point(12, 37);
            this.txt_QueryTitle.Name = "txt_QueryTitle";
            this.txt_QueryTitle.Size = new System.Drawing.Size(354, 22);
            this.txt_QueryTitle.TabIndex = 1;
            // 
            // btn_QueryCancel
            // 
            this.btn_QueryCancel.Location = new System.Drawing.Point(12, 258);
            this.btn_QueryCancel.Name = "btn_QueryCancel";
            this.btn_QueryCancel.Size = new System.Drawing.Size(167, 45);
            this.btn_QueryCancel.TabIndex = 2;
            this.btn_QueryCancel.Text = "Cancel";
            this.btn_QueryCancel.UseVisualStyleBackColor = true;
            this.btn_QueryCancel.Click += new System.EventHandler(this.btn_QueryCancel_Click);
            // 
            // btn_QuerySave
            // 
            this.btn_QuerySave.Location = new System.Drawing.Point(204, 258);
            this.btn_QuerySave.Name = "btn_QuerySave";
            this.btn_QuerySave.Size = new System.Drawing.Size(162, 45);
            this.btn_QuerySave.TabIndex = 3;
            this.btn_QuerySave.Text = "Save";
            this.btn_QuerySave.UseVisualStyleBackColor = true;
            this.btn_QuerySave.Click += new System.EventHandler(this.btn_QuerySave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Query Text:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Query Title:";
            // 
            // NewQueryDialogueBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 315);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_QuerySave);
            this.Controls.Add(this.btn_QueryCancel);
            this.Controls.Add(this.txt_QueryTitle);
            this.Controls.Add(this.txt_QueryText);
            this.Name = "NewQueryDialogueBox";
            this.Text = "Table Query";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_QueryText;
        private System.Windows.Forms.TextBox txt_QueryTitle;
        private System.Windows.Forms.Button btn_QueryCancel;
        private System.Windows.Forms.Button btn_QuerySave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}