using System.Collections.ObjectModel;

namespace TODOMauiApp
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<TaskToDo> TaskToDos { get; set; } = new ObservableCollection<TaskToDo>();
        public MainPage()
        {
            TaskToDos.Add(new TaskToDo()
            {
                Title = "Ugotować obiad",
                IsComplete = false
            });

            TaskToDos.Add(new TaskToDo()
            {
                Title = "Wyjść z psem",
                IsComplete = true
            });

            TaskToDos.Add(new TaskToDo()
            {
                Title = "Posprzątać pokój",
                IsComplete = true
            });

            TaskToDos.Add(new TaskToDo()
            {
                Title = "Odrobić lekcje",
                IsComplete = false
            });
            InitializeComponent();
        }
    }
}
