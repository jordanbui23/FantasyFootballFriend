namespace FantasyFootballFriend {
    partial class Index {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.uxSearchButton = new System.Windows.Forms.Button();
            this.uxAddButton = new System.Windows.Forms.Button();
            this.uxDeleteButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uxSearchButton
            // 
            this.uxSearchButton.Location = new System.Drawing.Point(12, 126);
            this.uxSearchButton.Name = "uxSearchButton";
            this.uxSearchButton.Size = new System.Drawing.Size(193, 293);
            this.uxSearchButton.TabIndex = 0;
            this.uxSearchButton.Text = "Search";
            this.uxSearchButton.UseVisualStyleBackColor = true;
            this.uxSearchButton.Click += new System.EventHandler(this.uxSearchButton_Click);
            // 
            // uxAddButton
            // 
            this.uxAddButton.Location = new System.Drawing.Point(305, 126);
            this.uxAddButton.Name = "uxAddButton";
            this.uxAddButton.Size = new System.Drawing.Size(193, 293);
            this.uxAddButton.TabIndex = 1;
            this.uxAddButton.Text = "Add";
            this.uxAddButton.UseVisualStyleBackColor = true;
            this.uxAddButton.Click += new System.EventHandler(this.uxAddButton_Click);
            // 
            // uxDeleteButton
            // 
            this.uxDeleteButton.Location = new System.Drawing.Point(587, 126);
            this.uxDeleteButton.Name = "uxDeleteButton";
            this.uxDeleteButton.Size = new System.Drawing.Size(193, 293);
            this.uxDeleteButton.TabIndex = 2;
            this.uxDeleteButton.Text = "Delete";
            this.uxDeleteButton.UseVisualStyleBackColor = true;
            this.uxDeleteButton.Click += new System.EventHandler(this.uxDeleteButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(768, 89);
            this.label1.TabIndex = 3;
            this.label1.Text = "Fantasy Football Friend";
            // 
            // Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uxDeleteButton);
            this.Controls.Add(this.uxAddButton);
            this.Controls.Add(this.uxSearchButton);
            this.Name = "Index";
            this.Text = "Fantasy Football Friend";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button uxSearchButton;
        private Button uxAddButton;
        private Button uxDeleteButton;
        private Label label1;
    }
}