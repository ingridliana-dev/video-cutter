using System.Diagnostics;

namespace VideoCutterApp;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		Debug.WriteLine("%%%% CONSTRUTOR MainPage EXECUTADO %%%%");
		InitializeComponent();
	}

	private void OnSelectVideoClicked(object sender, EventArgs e)
	{
		Debug.WriteLine("OnSelectVideoClicked chamado");
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

