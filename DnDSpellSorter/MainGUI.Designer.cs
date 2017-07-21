namespace DnDSpellSorter
{
    partial class MainGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGUI));
            this.LBClass = new System.Windows.Forms.ListBox();
            this.LBLevel = new System.Windows.Forms.ListBox();
            this.LBSpell = new System.Windows.Forms.ListBox();
            this.TBClass = new System.Windows.Forms.TextBox();
            this.TBLevel = new System.Windows.Forms.TextBox();
            this.TBSpell = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.RTBSpellInfo = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // LBClass
            // 
            this.LBClass.FormattingEnabled = true;
            this.LBClass.Items.AddRange(new object[] {
            "All",
            "Artificer",
            "Barbarian",
            "Bard",
            "Cleric",
            "Druid",
            "Fighter",
            "Monk",
            "Paladin",
            "Ranger",
            "Sorcerer",
            "Warlock",
            "Wizard"});
            this.LBClass.Location = new System.Drawing.Point(12, 93);
            this.LBClass.Name = "LBClass";
            this.LBClass.Size = new System.Drawing.Size(178, 316);
            this.LBClass.TabIndex = 0;
            this.LBClass.SelectedIndexChanged += new System.EventHandler(this.LBClass_SelectedIndexChanged);
            // 
            // LBLevel
            // 
            this.LBLevel.FormattingEnabled = true;
            this.LBLevel.Items.AddRange(new object[] {
            "All",
            "Cantrip",
            "Level 1",
            "Level 2",
            "Level 3",
            "Level 4",
            "Level 5",
            "Level 6",
            "Level 7",
            "Level 8",
            "Level 9"});
            this.LBLevel.Location = new System.Drawing.Point(196, 93);
            this.LBLevel.Name = "LBLevel";
            this.LBLevel.Size = new System.Drawing.Size(178, 316);
            this.LBLevel.TabIndex = 1;
            this.LBLevel.SelectedIndexChanged += new System.EventHandler(this.LBLevel_SelectedIndexChanged);
            // 
            // LBSpell
            // 
            this.LBSpell.FormattingEnabled = true;
            this.LBSpell.Items.AddRange(new object[] {
            "[Spells]"});
            this.LBSpell.Location = new System.Drawing.Point(380, 93);
            this.LBSpell.Name = "LBSpell";
            this.LBSpell.Size = new System.Drawing.Size(178, 316);
            this.LBSpell.TabIndex = 2;
            this.LBSpell.SelectedIndexChanged += new System.EventHandler(this.LBSpells_SelectedIndexChanged);
            // 
            // TBClass
            // 
            this.TBClass.Enabled = false;
            this.TBClass.Location = new System.Drawing.Point(12, 67);
            this.TBClass.MaxLength = 25;
            this.TBClass.Name = "TBClass";
            this.TBClass.Size = new System.Drawing.Size(177, 20);
            this.TBClass.TabIndex = 3;
            this.TBClass.TextChanged += new System.EventHandler(this.TBClass_TextChanged);
            // 
            // TBLevel
            // 
            this.TBLevel.Enabled = false;
            this.TBLevel.Location = new System.Drawing.Point(197, 67);
            this.TBLevel.MaxLength = 25;
            this.TBLevel.Name = "TBLevel";
            this.TBLevel.Size = new System.Drawing.Size(177, 20);
            this.TBLevel.TabIndex = 4;
            this.TBLevel.TextChanged += new System.EventHandler(this.TBLevel_TextChanged);
            // 
            // TBSpell
            // 
            this.TBSpell.Location = new System.Drawing.Point(381, 67);
            this.TBSpell.MaxLength = 25;
            this.TBSpell.Name = "TBSpell";
            this.TBSpell.Size = new System.Drawing.Size(177, 20);
            this.TBSpell.TabIndex = 5;
            this.TBSpell.TextChanged += new System.EventHandler(this.TBSpell_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Class";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(196, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Level";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(380, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Spell";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(564, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(387, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Spell Information";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(730, 31);
            this.label5.TabIndex = 10;
            this.label5.Text = "DnD 5e Spell Sorter";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RTBSpellInfo
            // 
            this.RTBSpellInfo.Location = new System.Drawing.Point(567, 67);
            this.RTBSpellInfo.Name = "RTBSpellInfo";
            this.RTBSpellInfo.ReadOnly = true;
            this.RTBSpellInfo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.RTBSpellInfo.Size = new System.Drawing.Size(384, 342);
            this.RTBSpellInfo.TabIndex = 12;
            this.RTBSpellInfo.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 421);
            this.Controls.Add(this.RTBSpellInfo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBSpell);
            this.Controls.Add(this.TBLevel);
            this.Controls.Add(this.TBClass);
            this.Controls.Add(this.LBSpell);
            this.Controls.Add(this.LBLevel);
            this.Controls.Add(this.LBClass);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Spell Sorter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LBClass;
        private System.Windows.Forms.ListBox LBLevel;
        private System.Windows.Forms.ListBox LBSpell;
        private System.Windows.Forms.TextBox TBClass;
        private System.Windows.Forms.TextBox TBLevel;
        private System.Windows.Forms.TextBox TBSpell;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox RTBSpellInfo;
    }
}

