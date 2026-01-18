using System.Windows;
using System.Windows.Input;
using IdentityPasswordTool.Helpers;
using IdentityPasswordTool.Models;
using IdentityPasswordTool.Services;

namespace IdentityPasswordTool.ViewModels;

public class MainViewModel : BaseViewModel
{
    private string _plainPassword = "";
    private string _passwordHash = "";
    private int _iterationCount = 10000;
    private bool _useIdentityV3 = true;

    public string PlainPassword
    {
        get => _plainPassword;
        set { _plainPassword = value; OnPropertyChanged(); }
    }

    public string PasswordHash
    {
        get => _passwordHash;
        set { _passwordHash = value; OnPropertyChanged(); }
    }

    public int IterationCount
    {
        get => _iterationCount;
        set { _iterationCount = value; OnPropertyChanged(); }
    }

    public bool UseIdentityV3
    {
        get => _useIdentityV3;
        set { _useIdentityV3 = value; OnPropertyChanged(); }
    }

    public ICommand GenerateCommand { get; }

    private readonly PasswordHashService _hashService = new();

    // ✅ Nur ein Konstruktor
    public MainViewModel()
    {
        GenerateCommand = new RelayCommand(() =>
        {
            var options = new HashOptionsModel
            {
                IterationCount = this.IterationCount,
                UseIdentityV3 = this.UseIdentityV3
            };
            PasswordHash = _hashService.HashPassword(PlainPassword, options);
        });
    }
}