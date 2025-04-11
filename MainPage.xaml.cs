using System.Diagnostics;
using Microsoft.Maui.Storage;

namespace VideoCutterApp;

public partial class MainPage : ContentPage
{
	// Variável para armazenar o caminho do vídeo selecionado
	private string _selectedVideoPath = string.Empty;

	public MainPage()
	{
		Debug.WriteLine("%%%% CONSTRUTOR MainPage EXECUTADO %%%%");
		InitializeComponent();
	}

	// Método para seleção de vídeo principal
	private async void OnSelectVideoClicked(object sender, EventArgs e)
	{
		try
		{
			// Opções para o seletor de arquivos (tipos de vídeo)
			var videoFileType = new FilePickerFileType(
				new Dictionary<DevicePlatform, IEnumerable<string>>
				{
					{ DevicePlatform.WinUI, new[] { ".mp4", ".mov", ".avi", ".wmv", ".mkv" } }, // Windows
					{ DevicePlatform.macOS, new[] { "mp4", "mov", "avi", "mkv" } }, // macOS 
					// Adicionar outras plataformas se necessário (Android, iOS)
					{ DevicePlatform.Android, new[] { "video/*" } },
					{ DevicePlatform.iOS, new[] { "public.movie" } }, // UTType para vídeos
				});

			var options = new PickOptions
			{
				PickerTitle = "Selecione o arquivo de vídeo principal",
				FileTypes = videoFileType,
			};

			// Abrir o seletor de arquivos
			var result = await FilePicker.Default.PickAsync(options);
			if (result != null)
			{
				// Verificar se o tipo de arquivo é realmente um dos esperados (segurança extra)
				if (result.FileName.EndsWith(".mp4", StringComparison.OrdinalIgnoreCase) ||
					result.FileName.EndsWith(".mov", StringComparison.OrdinalIgnoreCase) ||
					result.FileName.EndsWith(".avi", StringComparison.OrdinalIgnoreCase) ||
					result.FileName.EndsWith(".wmv", StringComparison.OrdinalIgnoreCase) ||
					result.FileName.EndsWith(".mkv", StringComparison.OrdinalIgnoreCase))
				{
					_selectedVideoPath = result.FullPath;
					VideoPathLabel.Text = result.FullPath; // Atualiza o Label na UI
					Debug.WriteLine($"Vídeo selecionado: {_selectedVideoPath}");
				}
				else
				{
					await DisplayAlert("Erro", "Tipo de arquivo de vídeo inválido selecionado.", "OK");
					VideoPathLabel.Text = "Nenhum arquivo selecionado";
					_selectedVideoPath = string.Empty;
				}
			}
			else
			{
				// Usuário cancelou a seleção
				// VideoPathLabel.Text = "Nenhum arquivo selecionado"; // Opcional: resetar se cancelar
				// _selectedVideoPath = string.Empty;
				 Debug.WriteLine("Seleção de vídeo cancelada.");
			}
		}
		catch (Exception ex)
		{
			// Tratar possíveis erros (ex: permissões)
			Debug.WriteLine($"Erro ao selecionar vídeo: {ex.Message}");
			await DisplayAlert("Erro", $"Falha ao selecionar o arquivo: {ex.Message}", "OK");
			VideoPathLabel.Text = "Nenhum arquivo selecionado";
			 _selectedVideoPath = string.Empty;
		}
	}

	private void OnSelectImageClicked(object sender, EventArgs e)
	{
		Debug.WriteLine("OnSelectImageClicked chamado");
	}

	private void OnSelectSeloClicked(object sender, EventArgs e)
	{
		Debug.WriteLine("OnSelectSeloClicked chamado");
	}

	private void OnStartProcessingClicked(object sender, EventArgs e)
	{
		Debug.WriteLine("OnStartProcessingClicked chamado");
	}

	private void OnOpenFolderClicked(object sender, EventArgs e)
	{
		Debug.WriteLine("OnOpenFolderClicked chamado");
	}
}

