using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Lignite.Configuration;

namespace Lignite.Core
{
    /// <summary>
    /// The Betfair Data Engine lies at the hart of the Lignite project and does all the heavy lifting.
    /// Once a market is submitted for proccessing it will be processed according to the data load patern associated with it.
    /// </summary>
    public partial class BetfairDataEngine : Component
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BetfairDataEngine"/> class.
        /// </summary>
        public BetfairDataEngine()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BetfairDataEngine"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public BetfairDataEngine(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        private Settings configuration;

        /// <summary>
        /// Gets or sets the current configuration.
        /// </summary>
        /// <value>The configuration.</value>
        public Settings Configuration
        {
            get { return configuration; }
            set
            {
                if (configuration != null &&
                    configuration != value)
                {
                    InvokeConfigurationChanged(this, new EventArgs());
                }

                configuration = value;
            }
        }
        
        /// <summary>
        /// Occurs when the engine is started.
        /// </summary>
        public event EventHandler<EventArgs> Starting;

        /// <summary>
        /// Invokes the starting event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        internal void InvokeStarting(object sender, EventArgs e)
        {
            if(Starting != null)
                Starting(this, e);
        }

        /// <summary>
        /// Occurs when the engine is tarted.
        /// </summary>
        public event EventHandler<EventArgs> Started;

        /// <summary>
        /// Invokes the started event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        internal void InvokeStarted(object sender, EventArgs e)
        {
            if (Started != null)
                Started(this, e);
        }

        /// <summary>
        /// Occurs when the engine is tarted.
        /// </summary>
        public event EventHandler<EventArgs> Paused;

        /// <summary>
        /// Invokes the paused event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        internal void InvokePaused(object sender, EventArgs e)
        {
            if (Paused != null)
                Paused(this, e);
        }
        
        /// <summary>
        /// Occurs when the engine is tarted.
        /// </summary>
        public event EventHandler<EventArgs> Stopping;

        /// <summary>
        /// Invokes the stopping event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        internal void InvokeStopping(object sender, EventArgs e)
        {
            if (Stopping != null)
                Stopping(this, e);
        }

        /// <summary>
        /// Occurs when the engine is tarted.
        /// </summary>
        public event EventHandler<EventArgs> Stopped;

        /// <summary>
        /// Invokes the stopped event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        internal void InvokeStopped(object sender, EventArgs e)
        {
            if (Stopped != null)
                Stopped(this, e);
        }

        /// <summary>
        /// Occurs when an umhandled exception occured on one of the child threads.
        /// </summary>
        public event EventHandler<CaughtExceptionEventArgs> CaughtException;

        /// <summary>
        /// Invokes the caught unhandled exception event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        internal void InvokeCaughtException(object sender, CaughtExceptionEventArgs e)
        {
            if (CaughtException != null)
                CaughtException(this, e);
        }

        /// <summary>
        /// Occurs when the loaded configuration changed.
        /// If the engine is running it would need to be restarted to ensure the changes take effect.
        /// </summary>
        public event EventHandler<EventArgs> ConfigurationChanged;

        /// <summary>
        /// Invokes the configuration changed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        internal void InvokeConfigurationChanged(object sender, EventArgs e)
        {
            if (ConfigurationChanged != null)
                ConfigurationChanged(this, e);
        }

        /// <summary>
        /// The current state of the data engine.
        /// </summary>
        private DataEngineState state;

        /// <summary>
        /// Gets the data engine state.
        /// </summary>
        /// <value>The state.</value>
        public DataEngineState State
        {
            get { return state; }
            private set
            { 
                state = value;

                switch (state)
                {
                    case DataEngineState.Starting:
                        {
                            InvokeStarting(this, new EventArgs());
                            break;
                        }
                    case DataEngineState.Running:
                        {
                            InvokeStarted(this, new EventArgs());
                            break;
                        }
                    case DataEngineState.Paused:
                        {
                            InvokePaused(this, new EventArgs());
                            break;
                        }
                    case DataEngineState.Stopping:
                        {
                            InvokeStopping(this, new EventArgs());
                            break;
                        }
                    case DataEngineState.Stopped:
                        {
                            InvokeStopped(this, new EventArgs());
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public void Start()
        {
            coreTimer.Enabled = true;
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void Stop()
        {
            coreTimer.Enabled = false;
        }
        
        /// <summary>
        /// Pauses this instance.
        /// </summary>
        public void Pause()
        {
            if(!coreTimer.Enabled) coreTimer.Enabled = true;
            else  coreTimer.Enabled = false;
        }

        /// <summary>
        /// Handles the Tick event of the coreTimer control.
        /// This is the hart beat of the entire system and nothing happens at a rate faster than 50ms.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void coreTimer_Tick(object sender, EventArgs e)
        {

        }
    }

    /// <summary>
    /// The curent state of the engine.
    /// </summary>
    public enum DataEngineState
    {
        /// <summary>
        /// The engine is not currently running.
        /// </summary>
        Stopped,
        /// <summary>
        /// The engine is not currently stopping all the processes.
        /// </summary>
        Stopping,
        /// <summary>
        /// The engine is in the process of starting up.
        /// </summary>
        Starting,
        /// <summary>
        /// The engine is running.
        /// </summary>
        Running,
        /// <summary>
        /// The engine is paused.
        /// Working threads will be allowed to complete but no new threads will be started.
        /// </summary>
        Paused
    }
}
