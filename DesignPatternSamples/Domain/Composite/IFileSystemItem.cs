using System.Text;

namespace DesignPatternSamples.Domain.Composite
{
    public interface IFileSystemItem
    {
        string Display(string indentation);
    }

    public class File : IFileSystemItem
    {
        private readonly string name;
        StringBuilder sb = new StringBuilder();

        public File(string name)
        {
            this.name = name;
        }

        public string Display(string indentation)
        {
            //Console.WriteLine(indentation + name);
            sb.AppendLine(indentation + name);
            return sb.ToString();
        }

        public class Folder : IFileSystemItem
        {
            private readonly string name;
            private readonly List<IFileSystemItem> items;
            StringBuilder sb = new StringBuilder();

            public Folder(string name)
            {
                this.name = name;
                items = new List<IFileSystemItem>();
            }

            public void AddItem(IFileSystemItem item)
            {
                items.Add(item);
            }

            public string Display(string indentation)
            {
                // Console.WriteLine(indentation + "+ " + name);
                sb.AppendLine(indentation + "+ " + name);
                foreach (var item in items)
                {
                    sb.AppendLine(item.Display(indentation + "  "));
                }
                return sb.ToString();
            }
        }
    }

}
