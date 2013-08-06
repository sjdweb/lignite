using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Lignite.Engine.Events
{
    public class Broker
    {
        public static event EventHandler SubscriptionAdded;
        public static event EventHandler SubscriptionRemoved;

        private static volatile Broker instance;
        private static object syncRoot = new Object();
        private static Dictionary<string, List<Delegate>> subscriptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:EventBroker"/> class.
        /// </summary>
        private Broker()
        {
        }


        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static Broker Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new Broker();
                            subscriptions = new Dictionary<string, List<Delegate>>();
                        }
                    }
                }

                return instance;

            }
        }

        /// <summary>
        /// Gets or sets the internal subscriptions dictionary.
        /// </summary>
        /// <value>The subscriptions.</value>

        private static Dictionary<string, List<Delegate>> Subscriptions
        {
            get { return Broker.subscriptions; }
            set
            {
                lock (syncRoot)
                {
                    Broker.subscriptions = value;
                }
            }
        }


        /// <summary>
        /// Raises the subscription added event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private static void OnSubscriptionAdded(EventArgs e)
        {
            if (SubscriptionAdded != null)
                SubscriptionAdded(instance, e);
        }

        /// <summary>
        /// Raises the subscription removed event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private static void OnSubscriptionRemoved(EventArgs e)
        {
            if (SubscriptionRemoved != null)
                SubscriptionRemoved(instance, e);
        }


        /// <summary>
        /// Subscribe method to the specified event.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="method">The method Delegate to be invoked when Event fires.</param>
        public static void Subscribe(string id, Delegate method)
        {

            //Check if there is a existing event
            List<Delegate> delegates = null;

            if (Subscriptions == null)
                Subscriptions = new Dictionary<string, List<Delegate>>();

            if (Subscriptions.ContainsKey(id))
            {
                delegates = subscriptions[id];
            }
            else
            {
                delegates = new List<Delegate>();
                Subscriptions.Add(id, delegates);
            }


            delegates.Add(method);
            OnSubscriptionAdded(new EventArgs());

        }



        /// <summary>
        /// Unsubscribe method from event notifications
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="method">The method.</param>
        public static void Unsubscribe(string id, Delegate method)
        {
            if (Subscriptions.ContainsKey(id))
            {
                if (Subscriptions[id].Contains(method))
                {
                    Subscriptions[id].Remove(method);
                    OnSubscriptionRemoved(new EventArgs());
                }

                if (Subscriptions[id].Count == 0)
                    Subscriptions.Remove(id);

            }
        }

        public static void UnsubscribeAll()
        {
            if (subscriptions != null)
            {
                lock (subscriptions)
                {
                    subscriptions.Clear();
                }
            }
        }


        /// <summary>
        /// Fire the specified event and pass parameters.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="args">The args.</param>
        public static void Execute(string id, object sender, EventArgs e)
        {
            if (Subscriptions.ContainsKey(id))
            {
                for (int i = 0; i < Subscriptions[id].Count; i++)
                {
                    Delegate x = Subscriptions[id][i];
                    DynamicInvoke(id, x, sender, e);

                    if (!Subscriptions.ContainsKey(id))
                        break;
                }
            }
        }


        /// <summary>
        /// Checks to see if target of invocation is still a valid 
        /// (non-disposed objects). Then it dinamicly invokes Delegate.
        /// </summary>
        /// <param name="id">Event ID</param>
        /// <param name="x">Delegate to invoke</param>
        /// <param name="args">Object array of arguments</param>
        private static void DynamicInvoke(string id, Delegate x, object sender, EventArgs e)
        {
            if (x.Target is Control)
            {
                Control ctl = (Control)x.Target;

                if (ctl.IsDisposed)
                {
                    Unsubscribe(id, x);
                    return;
                }
            }

            if (x.Target == null)
            {
                Unsubscribe(id, x);
                return;
            }

            x.DynamicInvoke(sender, e);
        }
    }
}
