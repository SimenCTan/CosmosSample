using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosSample.MauiCRM.ViewModels;

public class DashboardViewModel:BaseViewModel
{
    private string userName;
    public string UserName
    {
        get { return userName; }
        set
        {
            SetProperty(ref userName, value);
        }
    }
    public DashboardViewModel() { }
}

