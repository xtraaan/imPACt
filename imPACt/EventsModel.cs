using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;


namespace imPACt

{
    public class EventsModel
    {
        public ICommand AddImpactCommand => new Command(AddImpact);

        public ICommand RemoveImpactCommand => new Command(RemoveImpact);

        public ICommand UpdateImpactCommand => new Command(UpdateImpact);

        public ObservableCollection<EventApp> ImpactEvents { get; set; }

        public string EventName { get; set; }
        public string SelectedImpactEvent { get; set; }
        public object impactevent { get; }

        public EventsModel()
        {
            ImpactEvents = new ObservableCollection<EventApp>();


            // images or no images?
            ImpactEvents.Add(new EventApp(1, "Data Science Workshop", "LSU", "img1.jpg"));
            ImpactEvents.Add(new EventApp(2, "Career Preparation", "IBM", "img2.jpg"));
            ImpactEvents.Add(new EventApp(3, "Astrophysics Talk", "Exxon", "img3.jpg"));
            ImpactEvents.Add(new EventApp(4, "Astrophysics Talk", "Chevron", "img4.jpg"));
            ImpactEvents.Add(new EventApp(5, "Astrophysics Talk", "UFL", "img5.jpg"));
            ImpactEvents.Add(new EventApp(6, "Astrophysics Talk", "UKY", "img6.jpg"));


            MessagingCenter.Subscribe<EventsFormPage, EventApp>(this, "EventsForm",
            (page, impactevent) =>
            {
                if(impactevent.ImpactEventId == 0)
                {
                    impactevent.ImpactEventId = ImpactEvents.Count + 1;
                    ImpactEvents.Add(impactevent);
                }

                else
                {
                    EventApp eventToEdit = ImpactEvents.Where(emp => emp.ImpactEventId == impactevent.ImpactEventId).FirstOrDefault();

                    int newIdex = ImpactEvents.IndexOf(eventToEdit);
                    ImpactEvents.Remove(eventToEdit);

                    ImpactEvents.Add(impactevent);
                    int oldIndex = ImpactEvents.IndexOf(impactevent);

                    ImpactEvents.Move(oldIndex, newIdex);

                }

            }
            );
        }

        public void AddImpact()
        {
        }

        public void RemoveImpact()
        {
        }

        public void UpdateImpact()
        {
        }
    }
}
