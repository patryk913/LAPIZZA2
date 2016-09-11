using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LAPIZZA2
{
    interface INavigation
    {
        IReadOnlyList<Page> NavigationStack { get; }
        IReadOnlyList<Page> ModalStack { get; }

        void RemovePage(Page page);
        void InsertPageBefore(Page page, Page before);

        Task PushAsync(Page page);
        Task<Page> PopAsync();
        Task PopToRootAsync();
        Task PushModalAsync(Page page);
        Task<Page> PopModalAsync();

        Task PushAsync(Page page, bool animated);
        Task<Page> PopAsync(bool animated);
        Task PopToRootAsync(bool animated);
        Task PushModalAsync(Page page, bool animated);
        Task<Page> PopModalAsync(bool animated);
    }
}
