using System;
using System.Collections.Generic;
using System.Text;
using ToDoCP.Data;
using Xamarin.Forms;

namespace ToDoCP.Views
{
    public class ToDoTaskPageCS : ContentPage
    {
        public ToDoTaskPageCS()
        {
            Title = "Todo Item";

            var nameEntry = new Entry();
            nameEntry.SetBinding(Entry.TextProperty, "Name");

            var notesEntry = new Entry();
            notesEntry.SetBinding(Entry.TextProperty, "Notes");

            var doneSwitch = new Switch();
            doneSwitch.SetBinding(Switch.IsToggledProperty, "Done");

            var saveButton = new Button { Text = "Save" };
            saveButton.Clicked += async (sender, e) =>
            {
                var todoTask = (ToDoTask)BindingContext;
                await App.Database.SaveItemAsync(todoTask);
                await Navigation.PopAsync();
            };

            var deleteButton = new Button { Text = "Delete" };
            deleteButton.Clicked += async (sender, e) =>
            {
                var todoTask = (ToDoTask)BindingContext;
                await App.Database.DeleteItemAsync(todoTask);
                await Navigation.PopAsync();
            };

            var cancelButton = new Button { Text = "Cancel" };
            cancelButton.Clicked += async (sender, e) =>
            {
                await Navigation.PopAsync();
            };

            var speakButton = new Button { Text = "Speak" };
            speakButton.Clicked += (sender, e) =>
            {
                var todoTask = (ToDoTask)BindingContext;
                DependencyService.Get<ITextToSpeech>().Speak(todoTask.Name + " " + todoTask.Notes);
            };

            Content = new StackLayout
            {
                Margin = new Thickness(20),
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children =
                {
                    new Label { Text = "Name" },
                    nameEntry,
                    new Label { Text = "Notes" },
                    notesEntry,
                    new Label { Text = "Done" },
                    doneSwitch,
                    saveButton,
                    deleteButton,
                    cancelButton,
                    speakButton
                }
            };
        }
    }
}

