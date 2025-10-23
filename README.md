# klasa-5B-2025-2026-aplikacje

Komputer 1, 3, 5, 7, 9, 11, 13, 15, 17



Komputer 2, 4, 6, 8, 10, 12, 14, 16


Referat 1.
Dostepne technologie (biblioteki) na platformie .net.
* aplikacje konsolowe
* aplikacje desktopowe/mobilne (np. WinForms, WPF, MAUI itp.)
* APS.NET
* i inne.


Referat 2

Czym jest sztuczna inteligencja? — definicje, historia i zastosowania

→ Wprowadzenie do pojęcia AI, od klasycznych algorytmów po uczenie maszynowe.

```csharp
#if WINDOWS
using Windows.Storage;
using Windows.Storage.Pickers;
using WinRT.Interop;
#endif
```` 

```csharp
#if WINDOWS
        async void SaveFileWindowsAsync(object sender, EventArgs e)
        {
            var picker = new FileSavePicker();
            picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            picker.FileTypeChoices.Add("Text file", new List<string> { ".txt" });
            picker.SuggestedFileName = "Tekst";

            // Powiązanie z oknem MAUI
            var window = Application.Current.Windows.First().Handler.PlatformView as Microsoft.UI.Xaml.Window;
            IntPtr hWnd = WindowNative.GetWindowHandle(window);
            InitializeWithWindow.Initialize(picker, hWnd);

            StorageFile file = await picker.PickSaveFileAsync();
            if (file != null)
            {    
                await File.WriteAllText(file.Path, "TO CO MAMY ZAPISAĆ");
            }
        }
#else
        async void SaveFileWindowsAsync(object sender, EventArgs e)
        {

        }
#endif
```` 
