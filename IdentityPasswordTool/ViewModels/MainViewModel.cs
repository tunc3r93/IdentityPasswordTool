using System.Windows;
using System.Windows.Input;
using IdentityPasswordTool.Helpers;
using IdentityPasswordTool.Models;
using IdentityPasswordTool.Services;

namespace IdentityPasswordTool.ViewModels;

public class MainViewModel : BaseViewModel
{
    private readonly PasswordHashService _hashService = new();

    public string PlainPassword { get; set; } = "";
    public string PasswordHash { get; set; } = "";

    public HashOptionsModel Options { get; } = new();

    public ICommand GenerateCommand { get; }

    public MainViewModel()
    {
        GenerateCommand = new RelayCommand(GenerateHash);
    }

    private void GenerateHash()
    {
        if (string.IsNullOrWhiteSpace(PlainPassword))
        {
            MessageBox.Show("Bitte Passwort eingeben");
            return;
        }

        PasswordHash = _hashService.HashPassword(PlainPassword, Options);
        OnPropertyChanged(nameof(PasswordHash));
    }
}