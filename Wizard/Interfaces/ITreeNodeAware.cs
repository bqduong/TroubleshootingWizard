using Wizard.Models;

namespace Wizard.Interfaces
{
    public interface ITreeNodeAware<T>
        where T : new()
    {
        TreeNode<T> Node { get; set; }
    }
}
