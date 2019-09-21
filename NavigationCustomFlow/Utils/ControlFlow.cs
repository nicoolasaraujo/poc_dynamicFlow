using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NavigationCustomFlow.View;

namespace NavigationCustomFlow.Utils
{
    public class ControlFlow : Application
    {
        private static ControlFlow InstanceFlow = null;

        private List<int> Sequence = null;

        private int head;

        private bool isPaused = false;

        public int Head
        {
            get { return this.head; }
        }

        private readonly Dictionary<int, Type> parserActivity = new Dictionary<int, Type>()
        {
            {0, new AcHome().GetType() },
            {1, new AcPac().GetType()  },
            {2, new AcRoutesBook().GetType()  }
        };

        private ControlFlow()
        {
            this.MockSequence();
        }

        private void MockSequence()
        {
            this.Sequence = new List<int>
            {
                1,
                0
            };
        }

        public static ControlFlow Instance
        {
            get
            {
                if (InstanceFlow == null)
                {
                    InstanceFlow = new ControlFlow();
                }

                return InstanceFlow;
            }
        }

        public void NextActivity(Android.Content.Context context)
        {
            this.head++;
            if (this.head > this.Sequence.Count)
                this.head = 0;
            Type temp = this.parserActivity[this.Sequence[this.head]];

            Intent intent = new Intent(context, temp);
            context.StartActivity(intent);
            var x = (Activity)context;
            x.Finish();
            x.Dispose();
        }

        public void PreviousActivity(Android.Content.Context context)
        {
            this.head--;
            if (this.head < 0)
                this.head = 0;
            Type temp = this.parserActivity[this.Sequence[this.head]];

            Intent intent = new Intent(context, temp);
            context.StartActivity(intent);
            var acContext = (Activity)context;
            acContext.Finish();
            acContext.Dispose();
        }

        public void PauseFlow(Android.Content.Context context)
        {
            Type temp = null;
            Intent intent = null;
            var acContext = (Activity)context;
            if (!this.isPaused)
            {
                temp = new MainActivity().GetType();
                intent = new Intent(context, temp);
            }
            else
            {
                temp = this.parserActivity[this.Sequence[this.head]];
                intent = new Intent(context, temp);
            }

            context.StartActivity(intent);
            acContext.Finish();
            acContext.Dispose();
            this.isPaused = !this.isPaused;
        }
    }
}