﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MCSkin3D
{
	public partial class DodgeBurnOptions : ToolOptionBase
	{
		public DodgeBurnOptions()
		{
			InitializeComponent();
		}

		public bool Inverted
		{
			get { return radioButton2.Checked; }
		}

		private void DodgeBurnOptions_Load(object sender, EventArgs e)
		{
			checkBox1.Checked = GlobalSettings.DodgeBurnIncremental;
			SetExposure(GlobalSettings.DodgeBurnExposure);
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			GlobalSettings.DodgeBurnIncremental = checkBox1.Checked;
		}

		bool _skipSet = false;
		void SetExposure(float f)
		{
			_skipSet = true;
			numericUpDown1.Value = (decimal)(f * 100.0f);
			trackBar1.Value = (int)(f * 100.0f);
			_skipSet = false;

			GlobalSettings.DodgeBurnExposure = f;
		}
		
		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			if (_skipSet)
				return;

			SetExposure((float)numericUpDown1.Value / 100.0f);
		}

		private void trackBar1_Scroll(object sender, EventArgs e)
		{
			if (_skipSet)
				return;

			SetExposure((float)trackBar1.Value / 100.0f);
		}

		public override void BoxShown()
		{
			groupBox1.Controls.Add(Brushes.BrushBox);
			Brushes.BrushBox.Location = new Point(9, 19);
		}

		public override void BoxHidden()
		{
			Controls.Remove(Brushes.BrushBox);
		}

		private void groupBox2_Enter(object sender, EventArgs e)
		{

		}

	}
}