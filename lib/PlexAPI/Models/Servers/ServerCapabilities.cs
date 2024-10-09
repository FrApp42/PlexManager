using System.Xml.Serialization;

namespace PlexAPI.Models.Servers
{
    [XmlRoot(ElementName = "MediaContainer")]
    public class ServerCapabilities
    {
        [XmlAttribute("size")]
        public int Size { get; set; }

        [XmlAttribute("allowCameraUpload")]
        public int AllowCameraUpload { get; set; }

        [XmlAttribute("allowChannelAccess")]
        public int AllowChannelAccess { get; set; }

        [XmlAttribute("allowMediaDeletion")]
        public int AllowMediaDeletion { get; set; }

        [XmlAttribute("allowSharing")]
        public int AllowSharing { get; set; }

        [XmlAttribute("allowSync")]
        public int AllowSync { get; set; }

        [XmlAttribute("allowTuners")]
        public int AllowTuners { get; set; }

        [XmlAttribute("backgroundProcessing")]
        public int BackgroundProcessing { get; set; }

        [XmlAttribute("companionProxy")]
        public int CompanionProxy { get; set; }

        [XmlAttribute("countryCode")]
        public string CountryCode { get; set; }

        [XmlAttribute("diagnostics")]
        public string Diagnostics { get; set; }

        [XmlAttribute("eventStream")]
        public int EventStream { get; set; }

        [XmlAttribute("friendlyName")]
        public string FriendlyName { get; set; }

        [XmlAttribute("hubSearch")]
        public int HubSearch { get; set; }

        [XmlAttribute("itemClusters")]
        public int ItemClusters { get; set; }

        [XmlAttribute("livetv")]
        public int LiveTv { get; set; }

        [XmlAttribute("machineIdentifier")]
        public string MachineIdentifier { get; set; }

        [XmlAttribute("mediaProviders")]
        public int MediaProviders { get; set; }

        [XmlAttribute("multiuser")]
        public int Multiuser { get; set; }

        [XmlAttribute("musicAnalysis")]
        public int MusicAnalysis { get; set; }

        [XmlAttribute("myPlex")]
        public int MyPlex { get; set; }

        [XmlAttribute("myPlexMappingState")]
        public string MyPlexMappingState { get; set; }

        [XmlAttribute("myPlexSigninState")]
        public string MyPlexSigninState { get; set; }

        [XmlAttribute("myPlexSubscription")]
        public int MyPlexSubscription { get; set; }

        [XmlAttribute("myPlexUsername")]
        public string MyPlexUsername { get; set; }

        [XmlAttribute("offlineTranscode")]
        public int OfflineTranscode { get; set; }

        [XmlAttribute("photoAutoTag")]
        public int PhotoAutoTag { get; set; }

        [XmlAttribute("platform")]
        public string Platform { get; set; }

        [XmlAttribute("platformVersion")]
        public string PlatformVersion { get; set; }

        [XmlAttribute("pluginHost")]
        public int PluginHost { get; set; }

        [XmlAttribute("pushNotifications")]
        public int PushNotifications { get; set; }

        [XmlAttribute("readOnlyLibraries")]
        public int ReadOnlyLibraries { get; set; }

        [XmlAttribute("streamingBrainABRVersion")]
        public int StreamingBrainABRVersion { get; set; }

        [XmlAttribute("streamingBrainVersion")]
        public int StreamingBrainVersion { get; set; }

        [XmlAttribute("sync")]
        public int Sync { get; set; }

        [XmlAttribute("transcoderActiveVideoSessions")]
        public int TranscoderActiveVideoSessions { get; set; }

        [XmlAttribute("transcoderAudio")]
        public int TranscoderAudio { get; set; }

        [XmlAttribute("transcoderLyrics")]
        public int TranscoderLyrics { get; set; }

        [XmlAttribute("transcoderPhoto")]
        public int TranscoderPhoto { get; set; }

        [XmlAttribute("transcoderSubtitles")]
        public int TranscoderSubtitles { get; set; }

        [XmlAttribute("transcoderVideo")]
        public int TranscoderVideo { get; set; }

        [XmlAttribute("transcoderVideoBitrates")]
        public string TranscoderVideoBitrates { get; set; }

        [XmlAttribute("transcoderVideoQualities")]
        public string TranscoderVideoQualities { get; set; }

        [XmlAttribute("transcoderVideoResolutions")]
        public string TranscoderVideoResolutions { get; set; }

        [XmlAttribute("updatedAt")]
        public long UpdatedAt { get; set; }

        [XmlAttribute("updater")]
        public int Updater { get; set; }

        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlAttribute("voiceSearch")]
        public int VoiceSearch { get; set; }

        [XmlElement("Directory")]
        public List<Capability> Capabilities { get; set; }

        [XmlIgnore]
        public bool HasPlexPass { get
            {
                if (MyPlexSubscription == 0)
                    return false;
                else
                    return true;
            }
        }
    }
}
