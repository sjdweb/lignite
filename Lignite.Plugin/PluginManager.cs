/* @name Lignite For Betfair Project
 * @author Carel Vosloo
 * @author Betfair Developers Program (http://bdp.betfair.com)
 * @copyright Copyright (C) 2008 Betfair Ltd. All rights reserved.
 * @license This file is part of the Lignite For Betfair Project.
 * The BetfairAPIFramework is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * The "Lignite For Betfair Project" is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with the "Lignite For Betfair Project".  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.IO;
using System.Reflection;

namespace Lignite.Plugin
{
    public class PluginManager
    {
        #region PluginBaseMethods enum

        public enum PluginBaseMethods
        {
            ShowForm,
            StartUp,
            Execute,
            ShutDown
        }

        #endregion

        #region PluginBaseProperty enum

        public enum PluginBaseProperty
        {
            Name,
            Version,
            Description,
            Bets,
            HasWinForm,
            Configuration
        }

        #endregion

        private bool m_isLoaded;

        public PluginValues Settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="PluginManager"/> class.
        /// </summary>
        /// <param name="pluginLocation">The plugin location.</param>
        /// <param name="Configuration">The configuration.</param>
        public PluginManager(string pluginLocation, PluginConfigurationBase Configuration)
        {
            Settings = new PluginValues {dllLocation = pluginLocation};

            LoadPluginDll();

            if (!m_isLoaded) return;

            Settings.Name = GetIPluginBasePropertyValue<string>(PluginBaseProperty.Name);
            Settings.Version = GetIPluginBasePropertyValue<string>(PluginBaseProperty.Version);
            Settings.Description = GetIPluginBasePropertyValue<string>(PluginBaseProperty.Description);
            Settings.hasForm = GetIPluginBasePropertyValue<bool>(PluginBaseProperty.HasWinForm);
            SetIPluginBasePropertyValue(PluginBaseProperty.Configuration, Configuration);
        }

        /// <summary>
        /// At the core of this project is the idea of seperating the strategy functions
        /// and Betfair data load etc so that we can (as a community of developers) build
        /// the underlying framework but not necasarily expose our strategies.
        /// This bit of code loads and initializes the guts of what we do.
        /// </summary>
        private void LoadPluginDll()
        {
            if (!File.Exists(Settings.dllLocation)) return;

            Settings.dllAssembly = Assembly.LoadFrom(Settings.dllLocation);

            foreach (var typeLoop in Settings.dllAssembly.GetTypes())
            {
                // Pick up a class
                if (!typeLoop.IsClass) continue;

                // If it does not implement the IBase Interface, skip it
                if (typeLoop.GetInterface("Lignite.Plugin.IPluginBase") == null) continue;

                // If however, it does implement the IBase Interface,
                // create an instance of the object
                Settings.ibaseObject = Activator.CreateInstance(typeLoop);
                Settings.type = typeLoop;

                m_isLoaded = true;
            }
        }

        /// <summary>
        /// Shows the win form.
        /// </summary>
        public void ShowWinForm()
        {
            if (Settings.dllAssembly != null && Settings.ibaseObject != null)
            {
                // Dynamically Invoke the Object
                Settings.type.InvokeMember(PluginBaseMethods.ShowForm.ToString(),
                                           BindingFlags.Default | BindingFlags.InvokeMethod,
                                           null,
                                           Settings.ibaseObject,
                                           null);
            }
        }

        /// <summary>
        /// Getting a Property Value from Lignite.Engine.Strategies Ibase
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public T GetIPluginBasePropertyValue<T>(PluginBaseProperty name)
        {
            var result = Settings.type.InvokeMember(
                name.ToString(),
                BindingFlags.GetProperty,
                null,
                Settings.ibaseObject,
                null);

            return (T) result;
        }

        /// <summary>
        /// Setting Lignite.Engine.Strategies Ibase Property Value
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void SetIPluginBasePropertyValue<T>(PluginBaseProperty name, T value)
        {
            var temp = new object[1];
            temp[0] = value;

            Settings.type.InvokeMember(
                name.ToString(),
                BindingFlags.SetProperty,
                null,
                Settings.ibaseObject,
                temp);
        }

        #region Nested type: PluginValues

        public class PluginValues
        {
            public string Description;
            public Assembly dllAssembly;
            public string dllLocation;
            public bool hasForm;
            public object ibaseObject;
            private string m_id;
            public string Name;
            public Type type;
            public string Version;

            /// <summary>
            /// Gets the id for this session.
            /// Note: The id will change with each load.
            /// </summary>
            /// <value>The id.</value>
            public string id
            {
                get
                {
                    if (m_id == null)
                        m_id = Guid.NewGuid().ToString();
                    return m_id;
                }
            }
        }

        #endregion
    }
}