using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CosmosSample.Domain.Entities;
using System.Windows.Input;
using MvvmHelpers.Commands;

namespace CosmosSample.MauiCRM.ViewModels;

public class SalesViewModel : BaseViewModel
{
    private readonly SalesService _salesService;
    private List<MemberEntity> members;
    private string text;

    public ICommand SearchCommand { get; }

    public string Text
    {
        get { return text; }
        set
        {
            SetProperty(ref text, value);
        }
    }

    public List<MemberEntity> Members
    {
        get => members;
        set { SetProperty(ref members, value); }
    }
    public SalesViewModel(SalesService salesService)
    {
        _salesService = salesService;
        SearchCommand = new AsyncCommand(OnSearchCommandAsync);
    }

    private async Task OnSearchCommandAsync()
    {
        await Task.CompletedTask;
    }

    internal async Task InitializeAsync()
    {
        await GetAllMembers();
    }

    private async Task GetAllMembers()
    {
        members = await _salesService.GetSalesMembersAsync();
    }
}

