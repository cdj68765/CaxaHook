using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EasyHook;

namespace CaxaInject
{
    public class Main : EasyHook.IEntryPoint
    {
        private CaxaHook.HookDealWith Interface;
        LocalHook CreateFileHook;
        Stack<String> Queue = new Stack<String>();

        public Main(
            RemoteHooking.IContext InContext,
            String InChannelName)
        {
            // connect to host...
            Interface = RemoteHooking.IpcConnectClient<CaxaHook.HookDealWith>(InChannelName);
          //  Interface.Ping();
          
        }

        public void Run(
            RemoteHooking.IContext InContext,
            String InChannelName)
        {
            // install hook...
            try
            {

                /*  CreateFileHook = LocalHook.Create(
                      LocalHook.GetProcAddress("kernel32.dll", "MoveFileExW"),
                      new HookStgCreateStorageEx(StgCreateStorageEx_Hooked),
                      this);*/
                CreateFileHook = LocalHook.Create(
                    LocalHook.GetProcAddress("ole32.dll", "StgCreateStorageEx"),
                    new HookStgCreateStorageEx(StgCreateStorageEx_Hooked),
                    this);
                CreateFileHook.ThreadACL.SetExclusiveACL(new Int32[] { 0 });
                CreateFileHook.ThreadACL.SetInclusiveACL(new Int32[] { 0 });
            }
            catch (Exception ExtInfo)
            {
                Interface.ReportException(ExtInfo);

                return;
            }

            Interface.IsInstalled(RemoteHooking.GetCurrentThreadId());

            RemoteHooking.WakeUpProcess();
            // wait for host process termination...
            try
            {
                while (true)
                {
                    Thread.Sleep(500);

                    // transmit newly monitored file accesses...
                    if (Queue.Count > 0)
                    {
                        String[] Package = null;

                        lock (Queue)
                        {
                            Package = Queue.ToArray();

                            Queue.Clear();
                        }

                      //  Interface.OnCreateFile(RemoteHooking.GetCurrentProcessId(), Package);
                    }
                    else
                    {
                      //  Interface.Ping(RemoteHooking.GetCurrentThreadId());

                    }
                }
            }
            catch
            {
                // Ping() will raise an exception if host is unreachable
            }
        }
        public enum STGFMT
        {
            /// <summary>Indicates that the file must be a compound file.</summary>
            STGFMT_STORAGE = 0,
            /// <summary>Undocumented.</summary>
            STGFMT_NATIVE = 1,
            /// <summary>Indicates that the file must not be a compound file. This element is only valid when using the StgCreateStorageEx or StgOpenStorageEx functions to access the NTFS file system implementation of the IPropertySetStorage interface. Therefore, these functions return an error if the riid parameter does not specify the IPropertySetStorage interface, or if the specified file is not located on an NTFS file system volume.</summary>
            STGFMT_FILE = 3,
            /// <summary>Indicates that the system will determine the file type and use the appropriate structured storage or property set implementation. This value cannot be used with the StgCreateStorageEx function.</summary>
            STGFMT_ANY = 4,
            /// <summary>Indicates that the file must be a compound file, and is similar to the STGFMT_STORAGE flag, but indicates that the compound-file form of the compound-file implementation must be used. For more information, see Compound File Implementation Limits.</summary>
            STGFMT_DOCFILE = 5
        }
        public enum STGM
        {
            /// <summary>
            /// Indicates that the object is read-only, meaning that modifications cannot be made. For example, if a stream object is opened with STGM_READ, the
            /// ISequentialStream::Read method may be called, but the ISequentialStream::Write method may not. Similarly, if a storage object opened with
            /// STGM_READ, the IStorage::OpenStream and IStorage::OpenStorage methods may be called, but the IStorage::CreateStream and IStorage::CreateStorage
            /// methods may not.
            /// </summary>
            STGM_READ = 0x00000000,

            /// <summary>
            /// Enables you to save changes to the object, but does not permit access to its data. The provided implementations of the IPropertyStorage and
            /// IPropertySetStorage interfaces do not support this write-only mode.
            /// </summary>
            STGM_WRITE = 0x00000001,

            /// <summary>
            /// Enables access and modification of object data. For example, if a stream object is created or opened in this mode, it is possible to call both
            /// IStream::Read and IStream::Write. Be aware that this constant is not a simple binary OR operation of the STGM_WRITE and STGM_READ elements.
            /// </summary>
            STGM_READWRITE = 0x00000002,

            /// <summary>
            /// Specifies that subsequent openings of the object are not denied read or write access. If no flag from the sharing group is specified, this flag
            /// is assumed.
            /// </summary>
            STGM_SHARE_DENY_NONE = 0x00000040,

            /// <summary>Prevents others from subsequently opening the object in STGM_READ mode. It is typically used on a root storage object.</summary>
            STGM_SHARE_DENY_READ = 0x00000030,

            /// <summary>
            /// Prevents others from subsequently opening the object for STGM_WRITE or STGM_READWRITE access. In transacted mode, sharing of
            /// STGM_SHARE_DENY_WRITE or STGM_SHARE_EXCLUSIVE can significantly improve performance because they do not require snapshots. For more information
            /// about transactioning, see the Remarks section.
            /// </summary>
            STGM_SHARE_DENY_WRITE = 0x00000020,

            /// <summary>
            /// Prevents others from subsequently opening the object in any mode. Be aware that this value is not a simple bitwise OR operation of the
            /// STGM_SHARE_DENY_READ and STGM_SHARE_DENY_WRITE values. In transacted mode, sharing of STGM_SHARE_DENY_WRITE or STGM_SHARE_EXCLUSIVE can
            /// significantly improve performance because they do not require snapshots. For more information about transactioning, see the Remarks section.
            /// </summary>
            STGM_SHARE_EXCLUSIVE = 0x00000010,

            /// <summary>
            /// Opens the storage object with exclusive access to the most recently committed version. Thus, other users cannot commit changes to the object
            /// while you have it open in priority mode. You gain performance benefits for copy operations, but you prevent others from committing changes. Limit
            /// the time that objects are open in priority mode. You must specify STGM_DIRECT and STGM_READ with priority mode, and you cannot specify
            /// STGM_DELETEONRELEASE. STGM_DELETEONRELEASE is only valid when creating a root object, such as with StgCreateStorageEx. It is not valid when
            /// opening an existing root object, such as with StgOpenStorageEx. It is also not valid when creating or opening a subelement, such as with IStorage::OpenStorage.
            /// </summary>
            STGM_PRIORITY = 0x00040000,

            /// <summary>
            /// Indicates that an existing storage object or stream should be removed before the new object replaces it. A new object is created when this flag
            /// is specified only if the existing object has been successfully removed.
            /// <para>This flag is used when attempting to create:</para>
            /// <para>* A storage object on a disk, but a file of that name exists.</para>
            /// <para>* An object inside a storage object, but an object with the specified name exists.</para>
            /// <para>* A byte array object, but one with the specified name exists.</para>
            /// <para>This flag cannot be used with open operations, such as StgOpenStorageEx or IStorage::OpenStream.</para>
            /// </summary>
            STGM_CREATE = 0x00001000,

            /// <summary>
            /// Creates the new object while preserving existing data in a stream named "Contents". In the case of a storage object or a byte array, the old data
            /// is formatted into a stream regardless of whether the existing file or byte array currently contains a layered storage object. This flag can only
            /// be used when creating a root storage object. It cannot be used within a storage object; for example, in IStorage::CreateStream. It is also not
            /// valid to use this flag and the STGM_DELETEONRELEASE flag simultaneously.
            /// </summary>
            STGM_CONVERT = 0x00020000,

            /// <summary>
            /// Causes the create operation to fail if an existing object with the specified name exists. In this case, STG_E_FILEALREADYEXISTS is returned. This
            /// is the default creation mode; that is, if no other create flag is specified, STGM_FAILIFTHERE is implied.
            /// </summary>
            STGM_FAILIFTHERE = 0x00000000,

            /// <summary>
            /// Indicates that, in direct mode, each change to a storage or stream element is written as it occurs. This is the default if neither STGM_DIRECT
            /// nor STGM_TRANSACTED is specified.
            /// </summary>
            STGM_DIRECT = 0x00000000,

            /// <summary>
            /// Indicates that, in transacted mode, changes are buffered and written only if an explicit commit operation is called. To ignore the changes, call
            /// the Revert method in the IStream, IStorage, or IPropertyStorage interface. The COM compound file implementation of IStorage does not support
            /// transacted streams, which means that streams can be opened only in direct mode, and you cannot revert changes to them, however transacted
            /// storages are supported. The compound file, stand-alone, and NTFS file system implementations of IPropertySetStorage similarly do not support
            /// transacted, simple property sets because these property sets are stored in streams. However, transactioning of nonsimple property sets, which can
            /// be created by specifying the PROPSETFLAG_NONSIMPLE flag in the grfFlags parameter of IPropertySetStorage::Create, are supported.
            /// </summary>
            STGM_TRANSACTED = 0x00010000,

            /// <summary>
            /// Indicates that, in transacted mode, a temporary scratch file is usually used to save modifications until the Commit method is called. Specifying
            /// STGM_NOSCRATCH permits the unused portion of the original file to be used as work space instead of creating a new file for that purpose. This
            /// does not affect the data in the original file, and in certain cases can result in improved performance. It is not valid to specify this flag
            /// without also specifying STGM_TRANSACTED, and this flag may only be used in a root open. For more information about NoScratch mode, see the
            /// Remarks section.
            /// </summary>
            STGM_NOSCRATCH = 0x00100000,

            /// <summary>
            /// This flag is used when opening a storage object with STGM_TRANSACTED and without STGM_SHARE_EXCLUSIVE or STGM_SHARE_DENY_WRITE. In this case,
            /// specifying STGM_NOSNAPSHOT prevents the system-provided implementation from creating a snapshot copy of the file. Instead, changes to the file
            /// are written to the end of the file. Unused space is not reclaimed unless consolidation is performed during the commit, and there is only one
            /// current writer on the file. When the file is opened in no snapshot mode, another open operation cannot be performed without specifying
            /// STGM_NOSNAPSHOT. This flag may only be used in a root open operation. For more information about NoSnapshot mode, see the Remarks section.
            /// </summary>
            STGM_NOSNAPSHOT = 0x00200000,

            /// <summary>
            /// Provides a faster implementation of a compound file in a limited, but frequently used, case. For more information, see the Remarks section.
            /// </summary>
            STGM_SIMPLE = 0x08000000,

            /// <summary>Supports direct mode for single-writer, multireader file operations. For more information, see the Remarks section.</summary>
            STGM_DIRECT_SWMR = 0x00400000,

            /// <summary>
            /// Indicates that the underlying file is to be automatically destroyed when the root storage object is released. This feature is most useful for
            /// creating temporary files. This flag can only be used when creating a root object, such as with StgCreateStorageEx. It is not valid when opening a
            /// root object, such as with StgOpenStorageEx, or when creating or opening a subelement, such as with IStorage::CreateStream. It is also not valid
            /// to use this flag and the STGM_CONVERT flag simultaneously.
            /// </summary>
            STGM_DELETEONRELEASE = 0x04000000,
        }
        public enum FileFlagsAndAttributes : uint
        {
            /// <summary>
            /// A file that is read-only. Applications can read the file, but cannot write to it or delete it. This attribute is not honored on directories. For
            /// more information, see You cannot view or change the Read-only or the System attributes of folders in Windows Server 2003, in Windows XP, in
            /// Windows Vista or in Windows 7.
            /// </summary>
            FILE_ATTRIBUTE_READONLY = 0x00000001,
            /// <summary>The file or directory is hidden. It is not included in an ordinary directory listing.</summary>
            FILE_ATTRIBUTE_HIDDEN = 0x00000002,
            /// <summary>A file or directory that the operating system uses a part of, or uses exclusively.</summary>
            FILE_ATTRIBUTE_SYSTEM = 0x00000004,
            /// <summary>The handle that identifies a directory.</summary>
            FILE_ATTRIBUTE_DIRECTORY = 0x00000010,
            /// <summary>
            /// A file or directory that is an archive file or directory. Applications typically use this attribute to mark files for backup or removal .
            /// </summary>
            FILE_ATTRIBUTE_ARCHIVE = 0x00000020,
            /// <summary>This value is reserved for system use.</summary>
            FILE_ATTRIBUTE_DEVICE = 0x00000040,
            /// <summary>A file that does not have other attributes set. This attribute is valid only when used alone.</summary>
            FILE_ATTRIBUTE_NORMAL = 0x00000080,
            /// <summary>
            /// A file that is being used for temporary storage. File systems avoid writing data back to mass storage if sufficient cache memory is available,
            /// because typically, an application deletes a temporary file after the handle is closed. In that scenario, the system can entirely avoid writing
            /// the data. Otherwise, the data is written after the handle is closed.
            /// </summary>
            FILE_ATTRIBUTE_TEMPORARY = 0x00000100,
            /// <summary>A file that is a sparse file.</summary>
            FILE_ATTRIBUTE_SPARSE_FILE = 0x00000200,
            /// <summary>A file or directory that has an associated reparse point, or a file that is a symbolic link.</summary>
            FILE_ATTRIBUTE_REPARSE_POINT = 0x00000400,
            /// <summary>
            /// A file or directory that is compressed. For a file, all of the data in the file is compressed. For a directory, compression is the default for
            /// newly created files and subdirectories.
            /// </summary>
            FILE_ATTRIBUTE_COMPRESSED = 0x00000800,
            /// <summary>
            /// The data of a file is not available immediately. This attribute indicates that the file data is physically moved to offline storage. This
            /// attribute is used by Remote Storage, which is the hierarchical storage management software. Applications should not arbitrarily change this attribute.
            /// </summary>
            FILE_ATTRIBUTE_OFFLINE = 0x00001000,
            /// <summary>The file or directory is not to be indexed by the content indexing service.</summary>
            FILE_ATTRIBUTE_NOT_CONTENT_INDEXED = 0x00002000,
            /// <summary>
            /// A file or directory that is encrypted. For a file, all data streams in the file are encrypted. For a directory, encryption is the default for
            /// newly created files and subdirectories.
            /// </summary>
            FILE_ATTRIBUTE_ENCRYPTED = 0x00004000,
            /// <summary>
            /// The directory or user data stream is configured with integrity (only supported on ReFS volumes). It is not included in an ordinary directory
            /// listing. The integrity setting persists with the file if it's renamed. If a file is copied the destination file will have integrity set if either
            /// the source file or destination directory have integrity set.
            /// <para>
            /// <c>Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This flag is not supported
            /// until Windows Server 2012.
            /// </para>
            /// </summary>
            FILE_ATTRIBUTE_INTEGRITY_STREAM = 0x00008000,
            /// <summary>This value is reserved for system use.</summary>
            FILE_ATTRIBUTE_VIRTUAL = 0x00010000,
            /// <summary>
            /// The user data stream not to be read by the background data integrity scanner (AKA scrubber). When set on a directory it only provides
            /// inheritance. This flag is only supported on Storage Spaces and ReFS volumes. It is not included in an ordinary directory listing.
            /// <para>
            /// <c>Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This flag is not supported
            /// until Windows 8 and Windows Server 2012.
            /// </para>
            /// </summary>
            FILE_ATTRIBUTE_NO_SCRUB_DATA = 0x00020000,
            /// <summary>The file attribute ea</summary>
            FILE_ATTRIBUTE_EA = 0x00040000,
            /// <summary>
            /// Write operations will not go through any intermediate cache, they will go directly to disk.
            /// <para>For additional information, see the Caching Behavior section of this topic.</para>
            /// </summary>
            FILE_FLAG_WRITE_THROUGH = 0x80000000,
            /// <summary>
            /// The file or device is being opened or created for asynchronous I/O.
            /// <para>
            /// When subsequent I/O operations are completed on this handle, the event specified in the OVERLAPPED structure will be set to the signaled state.
            /// </para>
            /// <para>If this flag is specified, the file can be used for simultaneous read and write operations.</para>
            /// <para>
            /// If this flag is not specified, then I/O operations are serialized, even if the calls to the read and write functions specify an OVERLAPPED structure.
            /// </para>
            /// <para>
            /// For information about considerations when using a file handle created with this flag, see the Synchronous and Asynchronous I/O Handles section of
            /// this topic.
            /// </para>
            /// </summary>
            FILE_FLAG_OVERLAPPED = 0x40000000,
            /// <summary>
            /// The file or device is being opened with no system caching for data reads and writes. This flag does not affect hard disk caching or memory mapped files.
            /// <para>
            /// There are strict requirements for successfully working with files opened with CreateFile using the FILE_FLAG_NO_BUFFERING flag, for details see
            /// File Buffering.
            /// </para>
            /// </summary>
            FILE_FLAG_NO_BUFFERING = 0x20000000,
            /// <summary>
            /// Access is intended to be random. The system can use this as a hint to optimize file caching.
            /// <para>This flag has no effect if the file system does not support cached I/O and FILE_FLAG_NO_BUFFERING.</para>
            /// <para>For more information, see the Caching Behavior section of this topic.</para>
            /// </summary>
            FILE_FLAG_RANDOM_ACCESS = 0x10000000,
            /// <summary>
            /// Access is intended to be sequential from beginning to end. The system can use this as a hint to optimize file caching.
            /// <para>This flag should not be used if read-behind (that is, reverse scans) will be used.</para>
            /// <para>This flag has no effect if the file system does not support cached I/O and FILE_FLAG_NO_BUFFERING.</para>
            /// <para>For more information, see the Caching Behavior section of this topic.</para>
            /// </summary>
            FILE_FLAG_SEQUENTIAL_SCAN = 0x08000000,
            /// <summary>
            /// The file is to be deleted immediately after all of its handles are closed, which includes the specified handle and any other open or duplicated handles.
            /// <para>If there are existing open handles to a file, the call fails unless they were all opened with the FILE_SHARE_DELETE share mode.</para>
            /// <para>Subsequent open requests for the file fail, unless the FILE_SHARE_DELETE share mode is specified.</para>
            /// </summary>
            FILE_FLAG_DELETE_ON_CLOSE = 0x04000000,
            /// <summary>
            /// The file is being opened or created for a backup or restore operation. The system ensures that the calling process overrides file security checks
            /// when the process has SE_BACKUP_NAME and SE_RESTORE_NAME privileges. For more information, see Changing Privileges in a Token.
            /// <para>
            /// You must set this flag to obtain a handle to a directory. A directory handle can be passed to some functions instead of a file handle. For more
            /// information, see the Remarks section.
            /// </para>
            /// </summary>
            FILE_FLAG_BACKUP_SEMANTICS = 0x02000000,
            /// <summary>
            /// Access will occur according to POSIX rules. This includes allowing multiple files with names, differing only in case, for file systems that
            /// support that naming. Use care when using this option, because files created with this flag may not be accessible by applications that are written
            /// for MS-DOS or 16-bit Windows.
            /// </summary>
            FILE_FLAG_POSIX_SEMANTICS = 0x01000000,
            /// <summary>
            /// The file or device is being opened with session awareness. If this flag is not specified, then per-session devices (such as a device using
            /// RemoteFX USB Redirection) cannot be opened by processes running in session 0. This flag has no effect for callers not in session 0. This flag is
            /// supported only on server editions of Windows.
            /// <para><c>Windows Server 2008 R2 and Windows Server 2008:</c> This flag is not supported before Windows Server 2012.</para>
            /// </summary>
            FILE_FLAG_SESSION_AWARE = 0x00800000,
            /// <summary>
            /// Normal reparse point processing will not occur; CreateFile will attempt to open the reparse point. When a file is opened, a file handle is
            /// returned, whether or not the filter that controls the reparse point is operational.
            /// <para>This flag cannot be used with the CREATE_ALWAYS flag.</para>
            /// <para>If the file is not a reparse point, then this flag is ignored.</para>
            /// </summary>
            FILE_FLAG_OPEN_REPARSE_POINT = 0x00200000,
            /// <summary>
            /// The file data is requested, but it should continue to be located in remote storage. It should not be transported back to local storage. This flag
            /// is for use by remote storage systems.
            /// </summary>
            FILE_FLAG_OPEN_NO_RECALL = 0x00100000,
            /// <summary>
            /// If you attempt to create multiple instances of a pipe with this flag, creation of the first instance succeeds, but creation of the next instance
            /// fails with ERROR_ACCESS_DENIED.
            /// </summary>
            FILE_FLAG_FIRST_PIPE_INSTANCE = 0x00080000,
            /// <summary>Impersonates a client at the Anonymous impersonation level.</summary>
            SECURITY_ANONYMOUS = 0x00000000,
            /// <summary>Impersonates a client at the Identification impersonation level.</summary>
            SECURITY_IDENTIFICATION = 0x00010000,
            /// <summary>
            /// Impersonate a client at the impersonation level. This is the default behavior if no other flags are specified along with the
            /// SECURITY_SQOS_PRESENT flag.
            /// </summary>
            SECURITY_IMPERSONATION = 0x00020000,
            /// <summary>Impersonates a client at the Delegation impersonation level.</summary>
            SECURITY_DELEGATION = 0x00030000,
            /// <summary>The security tracking mode is dynamic. If this flag is not specified, the security tracking mode is static.</summary>
            SECURITY_CONTEXT_TRACKING = 0x00040000,
            /// <summary>
            /// Only the enabled aspects of the client's security context are available to the server. If you do not specify this flag, all aspects of the
            /// client's security context are available.
            /// <para>This allows the client to limit the groups and privileges that a server can use while impersonating the client.</para>
            /// </summary>
            SECURITY_EFFECTIVE_ONLY = 0x00080000,
            /// <summary>Include to enable the other SECURITY_ flags.</summary>
            SECURITY_SQOS_PRESENT = 0x00100000,
        }
        /*  [UnmanagedFunctionPointer(CallingConvention.StdCall,
              CharSet = CharSet.Unicode,
              SetLastError = true)]
          delegate IntPtr HookMoveFileEx(
              String OldFile,
              String NewFile,
              UInt32 dwFlags);*/
        [UnmanagedFunctionPointer(CallingConvention.StdCall,
            CharSet = CharSet.Unicode,
            SetLastError = true)]
        delegate IntPtr HookStgCreateStorageEx([MarshalAs(UnmanagedType.LPWStr)][In]  string pwcsName, [In] STGM grfMode,
            [In] STGFMT stgfmt, [In] FileFlagsAndAttributes grfAttrs, [In] IntPtr pStgOptions, [In] IntPtr pSecurityDescriptor, [In][MarshalAs(UnmanagedType.LPStruct)] Guid riid,
            [Out]  [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 6)] out object ppObjectOpen);

        // just use a P-Invoke implementation to get native API access from C# (this step is not necessary for C++.NET)
        /*   [DllImport("kernel32.dll",
               CharSet = CharSet.Unicode,
               SetLastError = true,
               CallingConvention = CallingConvention.StdCall)]
           static extern IntPtr MoveFileExW(
               String OldFile,
               String NewFile,
               UInt32 dwFlags);*/
        [DllImport("ole32.dll", CharSet = CharSet.Unicode, PreserveSig = false)]
        static extern IntPtr StgCreateStorageEx([MarshalAs(UnmanagedType.LPWStr)][In]  string pwcsName, [In] STGM grfMode,
            [In] STGFMT stgfmt, [In] FileFlagsAndAttributes grfAttrs, [In] IntPtr pStgOptions, [In] IntPtr pSecurityDescriptor, [In][MarshalAs(UnmanagedType.LPStruct)] Guid riid,
            [Out]  [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 6)] out object ppObjectOpen);

        static IntPtr StgCreateStorageEx_Hooked([MarshalAs(UnmanagedType.LPWStr)][In]  string pwcsName, [In] STGM grfMode,
            [In] STGFMT stgfmt, [In] FileFlagsAndAttributes grfAttrs, [In] IntPtr pStgOptions, [In] IntPtr pSecurityDescriptor, [In][MarshalAs(UnmanagedType.LPStruct)] Guid riid,
            [Out]  [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 6)] out object ppObjectOpen)
        {

            try
            {
                Main This = (Main) HookRuntimeInfo.Callback;

                lock (This.Queue)
                {
                    This.Interface.OnCreateFile(RemoteHooking.GetCurrentThreadId(), new[] {pwcsName});

                    /*This.Queue.Push("[" + RemoteHooking.GetCurrentProcessId() + ":" +
                        RemoteHooking.GetCurrentThreadId() + "]: \"" + InFileName + "\"");
                    InFileName = InFileName.Replace("C", "D");*/
                }
            }
            catch
            {
            }

            return StgCreateStorageEx(
                pwcsName, grfMode, stgfmt, grfAttrs,
                pStgOptions, pSecurityDescriptor,
                riid,
                out ppObjectOpen);
        }

        // this is where we are intercepting all file accesses!
        /*    static IntPtr MoveFileEx_Hooked(
                String OldFile,
                String NewFile,
                UInt32 dwFlags)
            {

                try
                {
                    Main This = (Main)HookRuntimeInfo.Callback;

                    lock (This.Queue)
                    {
                        This.Interface.OnCreateFile(RemoteHooking.GetCurrentThreadId(), new []{ OldFile, NewFile });
                        if (OldFile.EndsWith("$"))
                        {
                            NewFile = NewFile.Replace("D", "E");
                        }
                        else if (OldFile.EndsWith("exb"))
                        {
                            return new IntPtr(0);
                        }
                        /*This.Queue.Push("[" + RemoteHooking.GetCurrentProcessId() + ":" +
                            RemoteHooking.GetCurrentThreadId() + "]: \"" + InFileName + "\"");
                        InFileName = InFileName.Replace("C", "D");*/
        /*     }
         }
         catch
         {
         }

         // call original API...
          MoveFileExW(
             OldFile,
             NewFile,
             dwFlags);
         return new IntPtr(-1);
     }*/
    }
}
