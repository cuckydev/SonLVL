﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SonicRetro.SonLVL.API;

namespace SonicRetro.SonLVL
{
    public partial class FindObjectsDialog : Form
    {
        public FindObjectsDialog()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void findSubtype_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Enabled = findSubtype.Checked;
        }

        private void idSelect_ValueChanged(object sender, EventArgs e)
        {
            subtypeList.BeginUpdate();
            subtypeList.Items.Clear();
            imageList1.Images.Clear();
            if (LevelData.ObjTypes.ContainsKey(idSelect.Value))
            {
                byte value = LevelData.ObjTypes[idSelect.Value].DefaultSubtype;
                foreach (byte item in LevelData.ObjTypes[idSelect.Value].Subtypes)
                {
                    imageList1.Images.Add(LevelData.ObjTypes[idSelect.Value].SubtypeImage(item).Image.ToBitmap(LevelData.BmpPal).Resize(imageList1.ImageSize));
                    subtypeList.Items.Add(new ListViewItem(LevelData.ObjTypes[idSelect.Value].SubtypeName(item), imageList1.Images.Count - 1) { Tag = item, Selected = item == value });
                }
                subtypeSelect.Value = value;
            }
            subtypeList.EndUpdate();
        }

        private void subtypeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (subtypeList.SelectedIndices.Count > 0)
                subtypeSelect.Value = subtypeList.SelectedIndices[0];
        }
    }
}