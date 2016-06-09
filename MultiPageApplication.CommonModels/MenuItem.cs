using System.Windows.Input;

namespace MultiPageApplication.CommonModels
{
    public class MenuItem
    {
        public string Text { get; set; }
        public ICommand Command { get; set; }
    }
}
