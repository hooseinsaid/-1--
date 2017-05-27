namespace дерево
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.radioButtonAVL = new System.Windows.Forms.RadioButton();
            this.radioButtonBST = new System.Windows.Forms.RadioButton();
            this.textBoxItem = new System.Windows.Forms.TextBox();
            this.buttSearchNode = new System.Windows.Forms.Button();
            this.buttDeleteNode = new System.Windows.Forms.Button();
            this.buttAddNode = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.tabControl2);
            this.panel1.Location = new System.Drawing.Point(3, -2);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1218, 458);
            this.panel1.TabIndex = 0;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Location = new System.Drawing.Point(4, 4);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(169, 452);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Gray;
            this.tabPage3.Controls.Add(this.radioButtonAVL);
            this.tabPage3.Controls.Add(this.radioButtonBST);
            this.tabPage3.Controls.Add(this.textBoxItem);
            this.tabPage3.Controls.Add(this.buttSearchNode);
            this.tabPage3.Controls.Add(this.buttDeleteNode);
            this.tabPage3.Controls.Add(this.buttAddNode);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage3.Size = new System.Drawing.Size(161, 423);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "tabPage3";
            // 
            // radioButtonAVL
            // 
            this.radioButtonAVL.AutoSize = true;
            this.radioButtonAVL.Checked = true;
            this.radioButtonAVL.Location = new System.Drawing.Point(39, 58);
            this.radioButtonAVL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonAVL.Name = "radioButtonAVL";
            this.radioButtonAVL.Size = new System.Drawing.Size(55, 21);
            this.radioButtonAVL.TabIndex = 0;
            this.radioButtonAVL.TabStop = true;
            this.radioButtonAVL.Text = "AVL";
            this.radioButtonAVL.UseVisualStyleBackColor = true;
            // 
            // radioButtonBST
            // 
            this.radioButtonBST.AutoSize = true;
            this.radioButtonBST.Location = new System.Drawing.Point(40, 18);
            this.radioButtonBST.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonBST.Name = "radioButtonBST";
            this.radioButtonBST.Size = new System.Drawing.Size(56, 21);
            this.radioButtonBST.TabIndex = 6;
            this.radioButtonBST.Text = "BST";
            this.radioButtonBST.UseVisualStyleBackColor = true;
            // 
            // textBoxItem
            // 
            this.textBoxItem.Location = new System.Drawing.Point(27, 171);
            this.textBoxItem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxItem.Name = "textBoxItem";
            this.textBoxItem.Size = new System.Drawing.Size(105, 22);
            this.textBoxItem.TabIndex = 4;
            // 
            // buttSearchNode
            // 
            this.buttSearchNode.Location = new System.Drawing.Point(27, 357);
            this.buttSearchNode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttSearchNode.Name = "buttSearchNode";
            this.buttSearchNode.Size = new System.Drawing.Size(109, 45);
            this.buttSearchNode.TabIndex = 2;
            this.buttSearchNode.Text = "Search For Node";
            this.buttSearchNode.UseVisualStyleBackColor = true;
            this.buttSearchNode.Click += new System.EventHandler(this.buttSearchNode_Click);
            // 
            // buttDeleteNode
            // 
            this.buttDeleteNode.Location = new System.Drawing.Point(27, 290);
            this.buttDeleteNode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttDeleteNode.Name = "buttDeleteNode";
            this.buttDeleteNode.Size = new System.Drawing.Size(109, 42);
            this.buttDeleteNode.TabIndex = 1;
            this.buttDeleteNode.Text = "Delete Node";
            this.buttDeleteNode.UseVisualStyleBackColor = true;
            this.buttDeleteNode.Click += new System.EventHandler(this.buttDeleteNode_Click);
            // 
            // buttAddNode
            // 
            this.buttAddNode.Location = new System.Drawing.Point(27, 226);
            this.buttAddNode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttAddNode.Name = "buttAddNode";
            this.buttAddNode.Size = new System.Drawing.Size(109, 44);
            this.buttAddNode.TabIndex = 0;
            this.buttAddNode.Text = "Add Node";
            this.buttAddNode.UseVisualStyleBackColor = true;
            this.buttAddNode.Click += new System.EventHandler(this.buttAddNode_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage4.Size = new System.Drawing.Size(161, 423);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(179, -2);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1057, 458);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(1049, 429);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "BST";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(1049, 429);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "AVL";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 455);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBoxItem;
        private System.Windows.Forms.Button buttSearchNode;
        private System.Windows.Forms.Button buttDeleteNode;
        private System.Windows.Forms.Button buttAddNode;
        private System.Windows.Forms.RadioButton radioButtonAVL;
        private System.Windows.Forms.RadioButton radioButtonBST;
    }
}

