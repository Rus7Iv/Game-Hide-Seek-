namespace Hide_and_Seek
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

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
            this.description = new System.Windows.Forms.TextBox();
            this.goHere = new System.Windows.Forms.Button();
            this.exits = new System.Windows.Forms.ComboBox();
            this.goThroughTheDoor = new System.Windows.Forms.Button();
            this.hide = new System.Windows.Forms.Button();
            this.check = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // description
            // 
            this.description.Location = new System.Drawing.Point(16, 15);
            this.description.Margin = new System.Windows.Forms.Padding(4);
            this.description.Multiline = true;
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(409, 190);
            this.description.TabIndex = 0;
            this.description.Text = "Прятки!";
            // 
            // goHere
            // 
            this.goHere.Location = new System.Drawing.Point(16, 215);
            this.goHere.Margin = new System.Windows.Forms.Padding(4);
            this.goHere.Name = "goHere";
            this.goHere.Size = new System.Drawing.Size(100, 26);
            this.goHere.TabIndex = 1;
            this.goHere.Text = "Идти сюда:";
            this.goHere.UseVisualStyleBackColor = true;
            this.goHere.Click += new System.EventHandler(this.goHere_Click);
            // 
            // exits
            // 
            this.exits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.exits.FormattingEnabled = true;
            this.exits.Location = new System.Drawing.Point(124, 215);
            this.exits.Margin = new System.Windows.Forms.Padding(4);
            this.exits.Name = "exits";
            this.exits.Size = new System.Drawing.Size(301, 24);
            this.exits.TabIndex = 2;
            // 
            // goThroughTheDoor
            // 
            this.goThroughTheDoor.Location = new System.Drawing.Point(16, 249);
            this.goThroughTheDoor.Margin = new System.Windows.Forms.Padding(4);
            this.goThroughTheDoor.Name = "goThroughTheDoor";
            this.goThroughTheDoor.Size = new System.Drawing.Size(411, 28);
            this.goThroughTheDoor.TabIndex = 3;
            this.goThroughTheDoor.Text = "Пройти в дверь";
            this.goThroughTheDoor.UseVisualStyleBackColor = true;
            this.goThroughTheDoor.Click += new System.EventHandler(this.goThroughTheDoor_Click);
            // 
            // hide
            // 
            this.hide.Location = new System.Drawing.Point(16, 320);
            this.hide.Margin = new System.Windows.Forms.Padding(4);
            this.hide.Name = "hide";
            this.hide.Size = new System.Drawing.Size(411, 28);
            this.hide.TabIndex = 7;
            this.hide.Text = "Прячься!";
            this.hide.UseVisualStyleBackColor = true;
            this.hide.Click += new System.EventHandler(this.hide_Click);
            // 
            // check
            // 
            this.check.Location = new System.Drawing.Point(16, 284);
            this.check.Margin = new System.Windows.Forms.Padding(4);
            this.check.Name = "check";
            this.check.Size = new System.Drawing.Size(411, 28);
            this.check.TabIndex = 6;
            this.check.Text = "Проверить";
            this.check.UseVisualStyleBackColor = true;
            this.check.Click += new System.EventHandler(this.check_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 359);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(409, 26);
            this.button1.TabIndex = 8;
            this.button1.Text = "Проверить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 326);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(409, 22);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "123";
            this.textBox1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 406);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.hide);
            this.Controls.Add(this.check);
            this.Controls.Add(this.goThroughTheDoor);
            this.Controls.Add(this.exits);
            this.Controls.Add(this.goHere);
            this.Controls.Add(this.description);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Прячься и ищи";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox description;
        private System.Windows.Forms.Button goHere;
        private System.Windows.Forms.ComboBox exits;
        private System.Windows.Forms.Button goThroughTheDoor;
        private System.Windows.Forms.Button hide;
        private System.Windows.Forms.Button check;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

