// Written by Jonathan Dibble, Microsoft Corporation
// CODE IS PROVIDED AS-IS WITH NO WARRIENTIES EXPRESSED OR IMPLIED.

namespace WMPDiscordRPC.WMP
{
	using System;
	using System.Windows.Forms;
	using System.Runtime.InteropServices;


	/// <summary>
	/// This is the actual Windows Media Control.
	/// </summary>
	[System.Windows.Forms.AxHost.ClsidAttribute("{6bf52a52-394a-11d3-b153-00c04f79faa6}")]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	public class RemotedWindowsMediaPlayer : AxHost,
		IOleServiceProvider,
		IOleClientSite
	{

        private IOleObject _oleObject = null;
        private WMPLib.IWMPPlayer4 ocx;

        public void DoInterfaceAttachment()
        {
            try
            {
                //Get the IOleObject for Windows Media Player.
                _oleObject = this.GetOcx() as IOleObject;

                //Set the Client Site for the WMP control.
                _oleObject.SetClientSite(this as IOleClientSite);

                this.ocx = ((WMPLib.IWMPPlayer4)(this.GetOcx()));
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }
        #region IOleServiceProvider Memebers - Working
        /// <summary>
        /// During SetClientSite, WMP calls this function to get the pointer to <see cref="RemoteHostInfo"/>.
        /// </summary>
        /// <param name="guidService">See MSDN for more information - we do not use this parameter.</param>
        /// <param name="riid">The Guid of the desired service to be returned.  For this application it will always match
        /// the Guid of <see cref="IWMPRemoteMediaServices"/>.</param>
        /// <returns></returns>
        IntPtr IOleServiceProvider.QueryService(ref Guid guidService, ref Guid riid)
		{
			//If we get to here, it means Media Player is requesting our IWMPRemoteMediaServices interface
			if (riid == new Guid("cbb92747-741f-44fe-ab5b-f1a48f3b2a59"))
			{
				IWMPRemoteMediaServices iwmp = new RemoteHostInfo();
				return Marshal.GetComInterfaceForObject(iwmp, typeof(IWMPRemoteMediaServices));
			}

			throw new System.Runtime.InteropServices.COMException("No Interface", (int) HResults.E_NOINTERFACE);
		}
		#endregion

		#region IOleClientSite Members
		/// <summary>
		/// Not in use.  See MSDN for details.
		/// </summary>
		/// <exception cref="System.Runtime.InteropServices.COMException">E_NOTIMPL</exception>
		void IOleClientSite.SaveObject() 
		{
			throw new System.Runtime.InteropServices.COMException("Not Implemented", (int) HResults.E_NOTIMPL);
		}

		/// <summary>
		/// Not in use.  See MSDN for details.
		/// </summary>
		/// <exception cref="System.Runtime.InteropServices.COMException"></exception>
		object IOleClientSite.GetMoniker(uint dwAssign, uint dwWhichMoniker)
		{
			throw new System.Runtime.InteropServices.COMException("Not Implemented", (int) HResults.E_NOTIMPL);
		}

		/// <summary>
		/// Not in use.  See MSDN for details.
		/// </summary>
		/// <exception cref="System.Runtime.InteropServices.COMException"></exception>
		object IOleClientSite.GetContainer() 
		{
			throw new System.Runtime.InteropServices.COMException("Not Implemented", (int) HResults.E_NOTIMPL);
		}

		/// <summary>
		/// Not in use.  See MSDN for details.
		/// </summary>
		/// <exception cref="System.Runtime.InteropServices.COMException"></exception>
		void IOleClientSite.ShowObject() 		
		{
			throw new System.Runtime.InteropServices.COMException("Not Implemented", (int) HResults.E_NOTIMPL);
		}

		/// <summary>
		/// Not in use.  See MSDN for details.
		/// </summary>
		/// <exception cref="System.Runtime.InteropServices.COMException"></exception>
		void IOleClientSite.OnShowWindow(bool fShow) 		
		{
			throw new System.Runtime.InteropServices.COMException("Not Implemented", (int) HResults.E_NOTIMPL);
		}

		/// <summary>
		/// Not in use.  See MSDN for details.
		/// </summary>
		/// <exception cref="System.Runtime.InteropServices.COMException"></exception>
		void IOleClientSite.RequestNewObjectLayout() 		
		{
			throw new System.Runtime.InteropServices.COMException("Not Implemented", (int) HResults.E_NOTIMPL);
		}

		#endregion          

		/// <summary>
		/// Default Constructor.
		/// </summary>
		public RemotedWindowsMediaPlayer() : 
			base("6bf52a52-394a-11d3-b153-00c04f79faa6") 
		{
		}

        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.Runtime.InteropServices.DispIdAttribute(4)]
        public virtual WMPLib.IWMPControls Ctlcontrols
        {
            get
            {
                if (_oleObject == null)
                {
                    DoInterfaceAttachment();
                }

                if ((_oleObject == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("Ctlcontrols", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return ((WMPLib.IWMPPlayer4)_oleObject).controls;
            }
        }
    }   
}
