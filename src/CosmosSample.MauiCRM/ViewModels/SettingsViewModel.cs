using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosSample.MauiCRM.ViewModels;

public class SettingsViewModel : BaseViewModel
{
    public static string AppVersion { get => AppInfo.VersionString; }
    
    public SettingsViewModel() { }
}

