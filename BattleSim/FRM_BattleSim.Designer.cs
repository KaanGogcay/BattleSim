
namespace BattleSim
{
    partial class FRM_BattleSim
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LBL_GrarrlHitpoints = new System.Windows.Forms.Label();
            this.TB_GrarrlHitpoints = new System.Windows.Forms.TextBox();
            this.LBL_KorbatHitpoints = new System.Windows.Forms.Label();
            this.TB_KorbatHitpoints = new System.Windows.Forms.TextBox();
            this.BTN_KorbatAttacks = new System.Windows.Forms.Button();
            this.BTN_GrarrlAttacks = new System.Windows.Forms.Button();
            this.PB_Grarrl = new System.Windows.Forms.PictureBox();
            this.PB_Korbat = new System.Windows.Forms.PictureBox();
            this.LBL_CriticalHit = new System.Windows.Forms.Label();
            this.PB_AnotherOne = new System.Windows.Forms.PictureBox();
            this.PB_AndAnotherOne = new System.Windows.Forms.PictureBox();
            this.LBL_MissedAttack = new System.Windows.Forms.Label();
            this.BTN_Start = new System.Windows.Forms.Button();
            this.LBL_Damage = new System.Windows.Forms.Label();
            this.GB_KorbatAbility = new System.Windows.Forms.GroupBox();
            this.RB_Kor_DoubleDamagePoison = new System.Windows.Forms.RadioButton();
            this.RB_Kor_LifeSteal = new System.Windows.Forms.RadioButton();
            this.RB_Kor_Poison = new System.Windows.Forms.RadioButton();
            this.GB_GrarrlAbility = new System.Windows.Forms.GroupBox();
            this.RB_Gra_Triple = new System.Windows.Forms.RadioButton();
            this.RB_Gra_Evasion = new System.Windows.Forms.RadioButton();
            this.RB_Gra_DmgBoost = new System.Windows.Forms.RadioButton();
            this.LBL_PoisonNotification = new System.Windows.Forms.Label();
            this.LBL_GrarrlHasBeenPoisoned = new System.Windows.Forms.Label();
            this.LBL_GrarrlHasBeenRecovered = new System.Windows.Forms.Label();
            this.LBL_GrarrlName = new System.Windows.Forms.Label();
            this.LBL_KorbatName = new System.Windows.Forms.Label();
            this.LBL_GrarrlHasEvaded = new System.Windows.Forms.Label();
            this.PB_DjKhaledOnCoach = new System.Windows.Forms.PictureBox();
            this.LBL_GameTitle = new System.Windows.Forms.Label();
            this.LBL_Lifesteal = new System.Windows.Forms.Label();
            this.LBL_DoubleKorbatAttack = new System.Windows.Forms.Label();
            this.LBL_GrarrlTripleAttack = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Grarrl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Korbat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_AnotherOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_AndAnotherOne)).BeginInit();
            this.GB_KorbatAbility.SuspendLayout();
            this.GB_GrarrlAbility.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_DjKhaledOnCoach)).BeginInit();
            this.SuspendLayout();
            // 
            // LBL_GrarrlHitpoints
            // 
            this.LBL_GrarrlHitpoints.AutoSize = true;
            this.LBL_GrarrlHitpoints.Location = new System.Drawing.Point(535, 22);
            this.LBL_GrarrlHitpoints.Name = "LBL_GrarrlHitpoints";
            this.LBL_GrarrlHitpoints.Size = new System.Drawing.Size(31, 20);
            this.LBL_GrarrlHitpoints.TabIndex = 16;
            this.LBL_GrarrlHitpoints.Text = "HP:";
            this.LBL_GrarrlHitpoints.Visible = false;
            // 
            // TB_GrarrlHitpoints
            // 
            this.TB_GrarrlHitpoints.Location = new System.Drawing.Point(572, 19);
            this.TB_GrarrlHitpoints.Name = "TB_GrarrlHitpoints";
            this.TB_GrarrlHitpoints.ReadOnly = true;
            this.TB_GrarrlHitpoints.Size = new System.Drawing.Size(33, 27);
            this.TB_GrarrlHitpoints.TabIndex = 15;
            this.TB_GrarrlHitpoints.Text = "320";
            this.TB_GrarrlHitpoints.Visible = false;
            // 
            // LBL_KorbatHitpoints
            // 
            this.LBL_KorbatHitpoints.AutoSize = true;
            this.LBL_KorbatHitpoints.Location = new System.Drawing.Point(65, 22);
            this.LBL_KorbatHitpoints.Name = "LBL_KorbatHitpoints";
            this.LBL_KorbatHitpoints.Size = new System.Drawing.Size(31, 20);
            this.LBL_KorbatHitpoints.TabIndex = 14;
            this.LBL_KorbatHitpoints.Text = "HP:";
            this.LBL_KorbatHitpoints.Visible = false;
            // 
            // TB_KorbatHitpoints
            // 
            this.TB_KorbatHitpoints.Location = new System.Drawing.Point(102, 19);
            this.TB_KorbatHitpoints.Name = "TB_KorbatHitpoints";
            this.TB_KorbatHitpoints.ReadOnly = true;
            this.TB_KorbatHitpoints.Size = new System.Drawing.Size(33, 27);
            this.TB_KorbatHitpoints.TabIndex = 13;
            this.TB_KorbatHitpoints.Text = "240";
            this.TB_KorbatHitpoints.Visible = false;
            // 
            // BTN_KorbatAttacks
            // 
            this.BTN_KorbatAttacks.Location = new System.Drawing.Point(12, 355);
            this.BTN_KorbatAttacks.Name = "BTN_KorbatAttacks";
            this.BTN_KorbatAttacks.Size = new System.Drawing.Size(300, 36);
            this.BTN_KorbatAttacks.TabIndex = 12;
            this.BTN_KorbatAttacks.Text = "Attack";
            this.BTN_KorbatAttacks.UseVisualStyleBackColor = true;
            this.BTN_KorbatAttacks.Visible = false;
            this.BTN_KorbatAttacks.Click += new System.EventHandler(this.BTN_KorbatAttacks_Click);
            // 
            // BTN_GrarrlAttacks
            // 
            this.BTN_GrarrlAttacks.Enabled = false;
            this.BTN_GrarrlAttacks.Location = new System.Drawing.Point(488, 355);
            this.BTN_GrarrlAttacks.Name = "BTN_GrarrlAttacks";
            this.BTN_GrarrlAttacks.Size = new System.Drawing.Size(300, 36);
            this.BTN_GrarrlAttacks.TabIndex = 11;
            this.BTN_GrarrlAttacks.Text = "Attack";
            this.BTN_GrarrlAttacks.UseVisualStyleBackColor = true;
            this.BTN_GrarrlAttacks.Visible = false;
            this.BTN_GrarrlAttacks.Click += new System.EventHandler(this.BTN_GrarrlAttacks_Click);
            // 
            // PB_Grarrl
            // 
            this.PB_Grarrl.Image = global::BattleSim.Properties.Resources.BS___Grarrl;
            this.PB_Grarrl.Location = new System.Drawing.Point(488, 49);
            this.PB_Grarrl.Name = "PB_Grarrl";
            this.PB_Grarrl.Size = new System.Drawing.Size(300, 300);
            this.PB_Grarrl.TabIndex = 10;
            this.PB_Grarrl.TabStop = false;
            this.PB_Grarrl.Visible = false;
            // 
            // PB_Korbat
            // 
            this.PB_Korbat.Image = global::BattleSim.Properties.Resources.BS___Korbat;
            this.PB_Korbat.Location = new System.Drawing.Point(12, 49);
            this.PB_Korbat.Name = "PB_Korbat";
            this.PB_Korbat.Size = new System.Drawing.Size(300, 300);
            this.PB_Korbat.TabIndex = 9;
            this.PB_Korbat.TabStop = false;
            this.PB_Korbat.Visible = false;
            // 
            // LBL_CriticalHit
            // 
            this.LBL_CriticalHit.AutoSize = true;
            this.LBL_CriticalHit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LBL_CriticalHit.Location = new System.Drawing.Point(359, 49);
            this.LBL_CriticalHit.Name = "LBL_CriticalHit";
            this.LBL_CriticalHit.Size = new System.Drawing.Size(80, 20);
            this.LBL_CriticalHit.TabIndex = 17;
            this.LBL_CriticalHit.Text = "Critical hit!";
            this.LBL_CriticalHit.Visible = false;
            this.LBL_CriticalHit.Click += new System.EventHandler(this.LBL_CriticalHit_Click);
            // 
            // PB_AnotherOne
            // 
            this.PB_AnotherOne.Image = global::BattleSim.Properties.Resources.BS_AnotherOne;
            this.PB_AnotherOne.Location = new System.Drawing.Point(336, 355);
            this.PB_AnotherOne.Name = "PB_AnotherOne";
            this.PB_AnotherOne.Size = new System.Drawing.Size(125, 112);
            this.PB_AnotherOne.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB_AnotherOne.TabIndex = 18;
            this.PB_AnotherOne.TabStop = false;
            this.PB_AnotherOne.Visible = false;
            // 
            // PB_AndAnotherOne
            // 
            this.PB_AndAnotherOne.Image = global::BattleSim.Properties.Resources.BS_AndAnotherOne;
            this.PB_AndAnotherOne.Location = new System.Drawing.Point(318, 190);
            this.PB_AndAnotherOne.Name = "PB_AndAnotherOne";
            this.PB_AndAnotherOne.Size = new System.Drawing.Size(165, 159);
            this.PB_AndAnotherOne.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB_AndAnotherOne.TabIndex = 19;
            this.PB_AndAnotherOne.TabStop = false;
            this.PB_AndAnotherOne.Visible = false;
            // 
            // LBL_MissedAttack
            // 
            this.LBL_MissedAttack.AutoSize = true;
            this.LBL_MissedAttack.Location = new System.Drawing.Point(380, 49);
            this.LBL_MissedAttack.Name = "LBL_MissedAttack";
            this.LBL_MissedAttack.Size = new System.Drawing.Size(42, 20);
            this.LBL_MissedAttack.TabIndex = 20;
            this.LBL_MissedAttack.Text = "Miss!";
            this.LBL_MissedAttack.Visible = false;
            // 
            // BTN_Start
            // 
            this.BTN_Start.BackColor = System.Drawing.Color.Maroon;
            this.BTN_Start.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BTN_Start.ForeColor = System.Drawing.Color.Orange;
            this.BTN_Start.Location = new System.Drawing.Point(560, 226);
            this.BTN_Start.Name = "BTN_Start";
            this.BTN_Start.Size = new System.Drawing.Size(164, 123);
            this.BTN_Start.TabIndex = 21;
            this.BTN_Start.Text = "Start";
            this.BTN_Start.UseVisualStyleBackColor = false;
            this.BTN_Start.Click += new System.EventHandler(this.BTN_Start_Click);
            // 
            // LBL_Damage
            // 
            this.LBL_Damage.Location = new System.Drawing.Point(318, 7);
            this.LBL_Damage.Name = "LBL_Damage";
            this.LBL_Damage.Size = new System.Drawing.Size(164, 42);
            this.LBL_Damage.TabIndex = 23;
            this.LBL_Damage.Text = "Korbat Starts";
            this.LBL_Damage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.LBL_Damage.Visible = false;
            // 
            // GB_KorbatAbility
            // 
            this.GB_KorbatAbility.Controls.Add(this.RB_Kor_DoubleDamagePoison);
            this.GB_KorbatAbility.Controls.Add(this.RB_Kor_LifeSteal);
            this.GB_KorbatAbility.Controls.Add(this.RB_Kor_Poison);
            this.GB_KorbatAbility.Location = new System.Drawing.Point(12, 405);
            this.GB_KorbatAbility.Name = "GB_KorbatAbility";
            this.GB_KorbatAbility.Size = new System.Drawing.Size(300, 123);
            this.GB_KorbatAbility.TabIndex = 26;
            this.GB_KorbatAbility.TabStop = false;
            this.GB_KorbatAbility.Text = "Korbat Ability";
            this.GB_KorbatAbility.Visible = false;
            // 
            // RB_Kor_DoubleDamagePoison
            // 
            this.RB_Kor_DoubleDamagePoison.AutoSize = true;
            this.RB_Kor_DoubleDamagePoison.Location = new System.Drawing.Point(6, 86);
            this.RB_Kor_DoubleDamagePoison.Name = "RB_Kor_DoubleDamagePoison";
            this.RB_Kor_DoubleDamagePoison.Size = new System.Drawing.Size(245, 24);
            this.RB_Kor_DoubleDamagePoison.TabIndex = 29;
            this.RB_Kor_DoubleDamagePoison.TabStop = true;
            this.RB_Kor_DoubleDamagePoison.Text = "x2 damage if enemy is poisoned";
            this.RB_Kor_DoubleDamagePoison.UseVisualStyleBackColor = true;
            // 
            // RB_Kor_LifeSteal
            // 
            this.RB_Kor_LifeSteal.AutoSize = true;
            this.RB_Kor_LifeSteal.Location = new System.Drawing.Point(6, 56);
            this.RB_Kor_LifeSteal.Name = "RB_Kor_LifeSteal";
            this.RB_Kor_LifeSteal.Size = new System.Drawing.Size(227, 24);
            this.RB_Kor_LifeSteal.TabIndex = 28;
            this.RB_Kor_LifeSteal.TabStop = true;
            this.RB_Kor_LifeSteal.Text = "40% Lifesteal (will never miss)";
            this.RB_Kor_LifeSteal.UseVisualStyleBackColor = true;
            // 
            // RB_Kor_Poison
            // 
            this.RB_Kor_Poison.AutoSize = true;
            this.RB_Kor_Poison.Location = new System.Drawing.Point(6, 26);
            this.RB_Kor_Poison.Name = "RB_Kor_Poison";
            this.RB_Kor_Poison.Size = new System.Drawing.Size(225, 24);
            this.RB_Kor_Poison.TabIndex = 27;
            this.RB_Kor_Poison.TabStop = true;
            this.RB_Kor_Poison.Text = "45% Chance to poison enemy";
            this.RB_Kor_Poison.UseVisualStyleBackColor = true;
            // 
            // GB_GrarrlAbility
            // 
            this.GB_GrarrlAbility.Controls.Add(this.RB_Gra_Triple);
            this.GB_GrarrlAbility.Controls.Add(this.RB_Gra_Evasion);
            this.GB_GrarrlAbility.Controls.Add(this.RB_Gra_DmgBoost);
            this.GB_GrarrlAbility.Location = new System.Drawing.Point(488, 405);
            this.GB_GrarrlAbility.Name = "GB_GrarrlAbility";
            this.GB_GrarrlAbility.Size = new System.Drawing.Size(300, 123);
            this.GB_GrarrlAbility.TabIndex = 30;
            this.GB_GrarrlAbility.TabStop = false;
            this.GB_GrarrlAbility.Text = "Grarrl Ability";
            this.GB_GrarrlAbility.Visible = false;
            // 
            // RB_Gra_Triple
            // 
            this.RB_Gra_Triple.AutoSize = true;
            this.RB_Gra_Triple.Location = new System.Drawing.Point(6, 86);
            this.RB_Gra_Triple.Name = "RB_Gra_Triple";
            this.RB_Gra_Triple.Size = new System.Drawing.Size(270, 24);
            this.RB_Gra_Triple.TabIndex = 29;
            this.RB_Gra_Triple.TabStop = true;
            this.RB_Gra_Triple.Text = "20% Chance to triple attack damage";
            this.RB_Gra_Triple.UseVisualStyleBackColor = true;
            // 
            // RB_Gra_Evasion
            // 
            this.RB_Gra_Evasion.AutoSize = true;
            this.RB_Gra_Evasion.Location = new System.Drawing.Point(6, 56);
            this.RB_Gra_Evasion.Name = "RB_Gra_Evasion";
            this.RB_Gra_Evasion.Size = new System.Drawing.Size(216, 24);
            this.RB_Gra_Evasion.TabIndex = 28;
            this.RB_Gra_Evasion.TabStop = true;
            this.RB_Gra_Evasion.Text = "35% Chance to evade attack";
            this.RB_Gra_Evasion.UseVisualStyleBackColor = true;
            // 
            // RB_Gra_DmgBoost
            // 
            this.RB_Gra_DmgBoost.AutoSize = true;
            this.RB_Gra_DmgBoost.Location = new System.Drawing.Point(6, 26);
            this.RB_Gra_DmgBoost.Name = "RB_Gra_DmgBoost";
            this.RB_Gra_DmgBoost.Size = new System.Drawing.Size(161, 24);
            this.RB_Gra_DmgBoost.TabIndex = 27;
            this.RB_Gra_DmgBoost.TabStop = true;
            this.RB_Gra_DmgBoost.Text = "40% Damage Boost";
            this.RB_Gra_DmgBoost.UseVisualStyleBackColor = true;
            // 
            // LBL_PoisonNotification
            // 
            this.LBL_PoisonNotification.AutoSize = true;
            this.LBL_PoisonNotification.ForeColor = System.Drawing.Color.Purple;
            this.LBL_PoisonNotification.Location = new System.Drawing.Point(611, 22);
            this.LBL_PoisonNotification.Name = "LBL_PoisonNotification";
            this.LBL_PoisonNotification.Size = new System.Drawing.Size(131, 20);
            this.LBL_PoisonNotification.TabIndex = 32;
            this.LBL_PoisonNotification.Text = "-5 poison damage";
            this.LBL_PoisonNotification.Visible = false;
            // 
            // LBL_GrarrlHasBeenPoisoned
            // 
            this.LBL_GrarrlHasBeenPoisoned.Location = new System.Drawing.Point(318, 89);
            this.LBL_GrarrlHasBeenPoisoned.Name = "LBL_GrarrlHasBeenPoisoned";
            this.LBL_GrarrlHasBeenPoisoned.Size = new System.Drawing.Size(165, 48);
            this.LBL_GrarrlHasBeenPoisoned.TabIndex = 33;
            this.LBL_GrarrlHasBeenPoisoned.Text = "Grarrl has been poisoned";
            this.LBL_GrarrlHasBeenPoisoned.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.LBL_GrarrlHasBeenPoisoned.Visible = false;
            // 
            // LBL_GrarrlHasBeenRecovered
            // 
            this.LBL_GrarrlHasBeenRecovered.Location = new System.Drawing.Point(318, 89);
            this.LBL_GrarrlHasBeenRecovered.Name = "LBL_GrarrlHasBeenRecovered";
            this.LBL_GrarrlHasBeenRecovered.Size = new System.Drawing.Size(165, 50);
            this.LBL_GrarrlHasBeenRecovered.TabIndex = 34;
            this.LBL_GrarrlHasBeenRecovered.Text = "Grarrl has been recovered from poison";
            this.LBL_GrarrlHasBeenRecovered.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.LBL_GrarrlHasBeenRecovered.Visible = false;
            // 
            // LBL_GrarrlName
            // 
            this.LBL_GrarrlName.AutoSize = true;
            this.LBL_GrarrlName.Location = new System.Drawing.Point(488, 22);
            this.LBL_GrarrlName.Name = "LBL_GrarrlName";
            this.LBL_GrarrlName.Size = new System.Drawing.Size(46, 20);
            this.LBL_GrarrlName.TabIndex = 35;
            this.LBL_GrarrlName.Text = "Grarrl";
            this.LBL_GrarrlName.Visible = false;
            // 
            // LBL_KorbatName
            // 
            this.LBL_KorbatName.AutoSize = true;
            this.LBL_KorbatName.Location = new System.Drawing.Point(12, 22);
            this.LBL_KorbatName.Name = "LBL_KorbatName";
            this.LBL_KorbatName.Size = new System.Drawing.Size(54, 20);
            this.LBL_KorbatName.TabIndex = 36;
            this.LBL_KorbatName.Text = "Korbat";
            this.LBL_KorbatName.Visible = false;
            // 
            // LBL_GrarrlHasEvaded
            // 
            this.LBL_GrarrlHasEvaded.Location = new System.Drawing.Point(317, 139);
            this.LBL_GrarrlHasEvaded.Name = "LBL_GrarrlHasEvaded";
            this.LBL_GrarrlHasEvaded.Size = new System.Drawing.Size(165, 50);
            this.LBL_GrarrlHasEvaded.TabIndex = 37;
            this.LBL_GrarrlHasEvaded.Text = "Grarrl has evaded the attack";
            this.LBL_GrarrlHasEvaded.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.LBL_GrarrlHasEvaded.Visible = false;
            // 
            // PB_DjKhaledOnCoach
            // 
            this.PB_DjKhaledOnCoach.Image = global::BattleSim.Properties.Resources.BS_DjKhaledOnCoach;
            this.PB_DjKhaledOnCoach.Location = new System.Drawing.Point(0, 0);
            this.PB_DjKhaledOnCoach.Name = "PB_DjKhaledOnCoach";
            this.PB_DjKhaledOnCoach.Size = new System.Drawing.Size(803, 542);
            this.PB_DjKhaledOnCoach.TabIndex = 38;
            this.PB_DjKhaledOnCoach.TabStop = false;
            // 
            // LBL_GameTitle
            // 
            this.LBL_GameTitle.BackColor = System.Drawing.Color.DarkRed;
            this.LBL_GameTitle.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LBL_GameTitle.ForeColor = System.Drawing.Color.Orange;
            this.LBL_GameTitle.Location = new System.Drawing.Point(445, 19);
            this.LBL_GameTitle.Name = "LBL_GameTitle";
            this.LBL_GameTitle.Size = new System.Drawing.Size(343, 137);
            this.LBL_GameTitle.TabIndex = 39;
            this.LBL_GameTitle.Text = "DJ Khaled\'s Neo-Strikeout";
            this.LBL_GameTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LBL_Lifesteal
            // 
            this.LBL_Lifesteal.AutoSize = true;
            this.LBL_Lifesteal.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.LBL_Lifesteal.Location = new System.Drawing.Point(141, 22);
            this.LBL_Lifesteal.Name = "LBL_Lifesteal";
            this.LBL_Lifesteal.Size = new System.Drawing.Size(75, 20);
            this.LBL_Lifesteal.TabIndex = 40;
            this.LBL_Lifesteal.Text = "+ x health";
            this.LBL_Lifesteal.Visible = false;
            // 
            // LBL_DoubleKorbatAttack
            // 
            this.LBL_DoubleKorbatAttack.Location = new System.Drawing.Point(318, 189);
            this.LBL_DoubleKorbatAttack.Name = "LBL_DoubleKorbatAttack";
            this.LBL_DoubleKorbatAttack.Size = new System.Drawing.Size(165, 50);
            this.LBL_DoubleKorbatAttack.TabIndex = 41;
            this.LBL_DoubleKorbatAttack.Text = "Korbat\'s attack has been doubled";
            this.LBL_DoubleKorbatAttack.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.LBL_DoubleKorbatAttack.Visible = false;
            // 
            // LBL_GrarrlTripleAttack
            // 
            this.LBL_GrarrlTripleAttack.Location = new System.Drawing.Point(317, 189);
            this.LBL_GrarrlTripleAttack.Name = "LBL_GrarrlTripleAttack";
            this.LBL_GrarrlTripleAttack.Size = new System.Drawing.Size(165, 50);
            this.LBL_GrarrlTripleAttack.TabIndex = 42;
            this.LBL_GrarrlTripleAttack.Text = "Grarrl\'s attack has been tripled";
            this.LBL_GrarrlTripleAttack.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.LBL_GrarrlTripleAttack.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(336, 255);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 19);
            this.label1.TabIndex = 44;
            this.label1.Text = "Made By CrossyChainsaw";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Visible = false;
            // 
            // FRM_Battle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.ClientSize = new System.Drawing.Size(800, 541);
            this.Controls.Add(this.LBL_GrarrlTripleAttack);
            this.Controls.Add(this.LBL_DoubleKorbatAttack);
            this.Controls.Add(this.LBL_Lifesteal);
            this.Controls.Add(this.BTN_Start);
            this.Controls.Add(this.LBL_GrarrlHasEvaded);
            this.Controls.Add(this.LBL_KorbatName);
            this.Controls.Add(this.LBL_GrarrlName);
            this.Controls.Add(this.LBL_GrarrlHasBeenRecovered);
            this.Controls.Add(this.LBL_GrarrlHasBeenPoisoned);
            this.Controls.Add(this.LBL_PoisonNotification);
            this.Controls.Add(this.GB_GrarrlAbility);
            this.Controls.Add(this.GB_KorbatAbility);
            this.Controls.Add(this.LBL_Damage);
            this.Controls.Add(this.LBL_MissedAttack);
            this.Controls.Add(this.LBL_CriticalHit);
            this.Controls.Add(this.LBL_GrarrlHitpoints);
            this.Controls.Add(this.TB_GrarrlHitpoints);
            this.Controls.Add(this.LBL_KorbatHitpoints);
            this.Controls.Add(this.TB_KorbatHitpoints);
            this.Controls.Add(this.BTN_KorbatAttacks);
            this.Controls.Add(this.BTN_GrarrlAttacks);
            this.Controls.Add(this.PB_Grarrl);
            this.Controls.Add(this.PB_Korbat);
            this.Controls.Add(this.LBL_GameTitle);
            this.Controls.Add(this.PB_DjKhaledOnCoach);
            this.Controls.Add(this.PB_AnotherOne);
            this.Controls.Add(this.PB_AndAnotherOne);
            this.Controls.Add(this.label1);
            this.Name = "FRM_Battle";
            this.Text = "DJ Khaled\'s Neo-Strikeout";
            ((System.ComponentModel.ISupportInitialize)(this.PB_Grarrl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Korbat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_AnotherOne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_AndAnotherOne)).EndInit();
            this.GB_KorbatAbility.ResumeLayout(false);
            this.GB_KorbatAbility.PerformLayout();
            this.GB_GrarrlAbility.ResumeLayout(false);
            this.GB_GrarrlAbility.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_DjKhaledOnCoach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBL_GrarrlHitpoints;
        private System.Windows.Forms.TextBox TB_GrarrlHitpoints;
        private System.Windows.Forms.Label LBL_KorbatHitpoints;
        private System.Windows.Forms.TextBox TB_KorbatHitpoints;
        private System.Windows.Forms.Button BTN_KorbatAttacks;
        private System.Windows.Forms.Button BTN_GrarrlAttacks;
        private System.Windows.Forms.PictureBox PB_Grarrl;
        private System.Windows.Forms.PictureBox PB_Korbat;
        private System.Windows.Forms.Label LBL_CriticalHit;
        private System.Windows.Forms.PictureBox PB_AnotherOne;
        private System.Windows.Forms.PictureBox PB_AndAnotherOne;
        private System.Windows.Forms.Label LBL_MissedAttack;
        private System.Windows.Forms.Button BTN_Start;
        private System.Windows.Forms.Label LBL_Damage;
        private System.Windows.Forms.GroupBox GB_KorbatAbility;
        private System.Windows.Forms.RadioButton RB_Kor_DoubleDamagePoison;
        private System.Windows.Forms.RadioButton RB_Kor_LifeSteal;
        private System.Windows.Forms.RadioButton RB_Kor_Poison;
        private System.Windows.Forms.GroupBox GB_GrarrlAbility;
        private System.Windows.Forms.RadioButton RB_Gra_Triple;
        private System.Windows.Forms.RadioButton RB_Gra_Evasion;
        private System.Windows.Forms.RadioButton RB_Gra_DmgBoost;
        private System.Windows.Forms.Label LBL_PoisonNotification;
        private System.Windows.Forms.Label LBL_GrarrlHasBeenPoisoned;
        private System.Windows.Forms.Label LBL_GrarrlHasBeenRecovered;
        private System.Windows.Forms.Label LBL_GrarrlName;
        private System.Windows.Forms.Label LBL_KorbatName;
        private System.Windows.Forms.Label LBL_GrarrlHasEvaded;
        private System.Windows.Forms.PictureBox PB_DjKhaledOnCoach;
        private System.Windows.Forms.Label LBL_GameTitle;
        private System.Windows.Forms.Label LBL_Lifesteal;
        private System.Windows.Forms.Label LBL_DoubleKorbatAttack;
        private System.Windows.Forms.Label LBL_GrarrlTripleAttack;
        private System.Windows.Forms.Label label1;
    }
}

