﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TpsControl;
using MethodMeter;

namespace MethodFlowControl
{
    public partial class Flow_MessBox : TpsControl.FlowFuncControl
    {
        public Flow_MessBox()
        {
            InitializeComponent();
            nameInit();
        }
        private void nameInit()
        {
            this.LabelText = "MessageBox";
            this.ButtonText = "Mes";
        }

        protected override void buildMeterControl(out BaseMeterControl meterControl)
        {
            //新建对应的meterControl，并且把新建控件加入meterControl中。
            int graphID = FlowFuncControl.FormControl.SelectedIndex;
            int tabID = BaseMeterControl.meterControl[FlowFuncControl.FormControl.SelectedIndex].Count;
            meterControl = new Meter_MessBox(graphID, tabID);
            return;
        }
    }
}
