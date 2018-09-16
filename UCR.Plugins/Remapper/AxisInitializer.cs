﻿using System;
using HidWizards.UCR.Core.Attributes;
using HidWizards.UCR.Core.Models;
using HidWizards.UCR.Core.Models.Binding;
using HidWizards.UCR.Core.Utilities;
using HidWizards.UCR.Core.Utilities.AxisHelpers;

namespace HidWizards.UCR.Plugins.Remapper
{
    [Plugin("Axis Initializer", Disabled = true)]
    [PluginOutput(DeviceBindingCategory.Range, "Axis")]
    public class AxisInitializer : Plugin
    {
        [PluginGui("Percentage", ColumnOrder = 0)]
        public decimal Percentage { get; set; }

        public AxisInitializer()
        {
        }

        public override void Update(params short[] values)
        {
        }

        private void Initialize()
        {
            var value = (int)((Percentage / 100) * Constants.AxisMaxAbsValue);
            WriteOutput(0, Functions.ClampAxisRange(value));
        }

        #region Event Handling
        public override void OnActivate()
        {
            base.OnActivate();
            Initialize();
        }

        public override void OnPropertyChanged()
        {
            base.OnPropertyChanged();
            Initialize();
        }
        #endregion
    }
}
