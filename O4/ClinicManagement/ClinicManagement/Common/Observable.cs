using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Common
{
    class Observable<T>
    {
        private T value;
        public List<Action<T>> observations = new List<Action<T>>();
        public static Observable<T> create(Action<Observable<T>> action)
        {
            var instance = new Observable<T>();
            action(instance);
            return instance;
        }

        public Observable(T value)
        {
            this.value = value;
        }

        public Observable()
        {
        }

        public void onNext(T value)
        {
            if (this.value != null && this.value.Equals(value))
                return;
            this.observations.ForEach(action =>
            {
               action(value);
            });
            this.value = value;
        }

        public void subscribe(Action<T> action)
        {
            this.observations.Add(action);
        }

        public void clear()
        {
            this.observations.Clear();
        }
    }
}
