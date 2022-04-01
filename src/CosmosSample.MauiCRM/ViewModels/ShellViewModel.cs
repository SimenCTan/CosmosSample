using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CosmosSample.MauiCRM.Resources.Strings;

namespace CosmosSample.MauiCRM.ViewModels;

public class ShellViewModel
{
    public AppSection Dashboard { get; set; }
    public AppSection Sales { get; set; }
    public AppSection Marketing { get; set; }
    public AppSection Settings { get; set; }

    public ShellViewModel()
    {
        Dashboard = new AppSection {
            Title=AppResource.Dashboard,
            Icon= "dashboard.png",
            TargetType= typeof(DashboardPage),
        };
        Sales = new AppSection
        {
            Title = AppResource.Sales,
            Icon = "sales.png",
            TargetType = typeof(SalesPage)
        };
        Marketing = new AppSection
        {
            Title = AppResource.Marketing,
            Icon = "marketing.png",
            TargetType = typeof(SalesPage)
        };
        Settings = new AppSection
        {
            Title = AppResource.Settings,
            Icon = "settings.png",
            TargetType = typeof(SettingsPage)
        };
    }
}

