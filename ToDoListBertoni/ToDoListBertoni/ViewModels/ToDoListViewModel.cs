using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDoListBertoni.Models;
using Xamarin.Forms;

namespace ToDoListBertoni.ViewModels
{
    public class ToDoListViewModel : BaseViewModel
    {
        private ObservableCollection<ToDoItem> _items;
        public ObservableCollection<ToDoItem> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        private ToDoItem _selectedItem;
        public ToDoItem SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        private string _newItemDescription;
        public string NewItemDescription
        {
            get { return _newItemDescription; }
            set
            {
                _newItemDescription = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectItemCommand { get; set; }
        public ICommand OpenNewItemCommand { get; set; }
        public ICommand AddNewItemCommand { get; set; }
        public ICommand DeleteItemCommand { get; set; }
        public ICommand CompleteItemCommand { get; set; }

        public ToDoListViewModel(Page context) : base(context)
        {
            SelectItemCommand = new Command(async (item) => await OnTodoItemSelected((ToDoItem)item));
            OpenNewItemCommand = new Command(async () => await OnNewTodoItemOpen());
            AddNewItemCommand = new Command(async () => await OnTodoItemAdded());
            DeleteItemCommand = new Command(async () => await OnTodoItemDeleted());
            CompleteItemCommand = new Command(async () => await OnTodoItemCompleted());

            _ = GetToDoItems();
        }

        private async Task GetToDoItems()
        {
            IsBusy = true;
            try
            {
                // Get items from DB
                var items = await App.DBContext.GetToDoItemsAsync();
                Items = new ObservableCollection<ToDoItem>(items);
            }
            catch(Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task OnTodoItemSelected(ToDoItem item)
        {
            // Open the item view
            SelectedItem = item;
            var view = new Views.ToDoItemView() { BindingContext = this };
            await Navigation.PushAsync(view);
        }

        private async Task OnNewTodoItemOpen()
        {
            // Open the new item view
            var view = new Views.NewToDoItemView() { BindingContext = this };
            await Navigation.PushAsync(view);
        }

        private async Task OnTodoItemAdded()
        {
            IsBusy = true;
            try
            {
                if (string.IsNullOrEmpty(NewItemDescription))
                {
                    return;
                }

                // Creates a new todo item
                var newItem = new ToDoItem
                {
                    Description = NewItemDescription,
                    Status = ToDoStatus.Incomplete
                };

                // Saves the item
                await App.DBContext.SaveToDoItemAsync(newItem);

                // Add the new item to the list
                Items.Add(newItem);

                NewItemDescription = "";
                await Navigation.PopAsync();
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task OnTodoItemDeleted()
        {
            IsBusy = true;
            try
            {
                if (SelectedItem == null)
                {
                    return;
                }

                // Deletes the selected item
               await App.DBContext.DeleteToDoItemAsync(SelectedItem);

                // Remove the selected item from the list
                Items.Remove(SelectedItem);

                SelectedItem = null;
                await Navigation.PopAsync();
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task OnTodoItemCompleted()
        {
            IsBusy = true;
            try
            {
                if (SelectedItem == null)
                {
                    return;
                }

                // Changes item status
                SelectedItem.Status = ToDoStatus.Complete;

                // Update the selected item
                await App.DBContext.SaveToDoItemAsync(SelectedItem);
                Items[Items.IndexOf(SelectedItem)] = SelectedItem;

                SelectedItem = null;
                await Navigation.PopAsync();
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
