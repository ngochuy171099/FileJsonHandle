using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using FileHanderJson.Entity;
using Newtonsoft.Json;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FileHanderJson
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Student student = new Student();
        public MainPage()
        {
            this.InitializeComponent();
            
        }

        private async void btnSave_click(object sender, RoutedEventArgs e)
        {
            this.student.name = this.Name.Text;
            this.student.email=this.Email.Text ;
            this.student.phone = this.Phone.Text;
            string content = Content.Text;

            string jsonStudent = JsonConvert.SerializeObject(this.student);
            FileSavePicker savePicker = new FileSavePicker();
            savePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            savePicker.FileTypeChoices.Add("Plan Text",new List<string>(){".txt"});
            savePicker.SuggestedFileName = content;
            StorageFile file = await savePicker.PickSaveFileAsync();
            await FileIO.WriteTextAsync(file, jsonStudent);
        }

        private async void btnRead_click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".txt");
            StorageFile file = await openPicker.PickSingleFileAsync();

            string content = await FileIO.ReadTextAsync(file);
            Student student = JsonConvert.DeserializeObject<Student>(content);
            this.Name.Text = student.name;
            this.Email.Text = student.email;
            this.Phone.Text = student.phone;
            this.Content.Text = file.Name;
            Debug.WriteLine(content);
        }
    }
}
