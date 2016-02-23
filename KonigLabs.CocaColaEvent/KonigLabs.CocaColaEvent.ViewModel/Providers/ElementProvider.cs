using KonigLabs.CocaColaEvent.Entities;
using KonigLabs.CocaColaEvent.Entities.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace KonigLabs.CocaColaEvent.ViewModel.Providers
{
    public class ElementProvider
    {
        private readonly string _filePath = "Prints.xml";
        private readonly string _womenPath = "womensize.xml";
        private readonly string _menPath = "mensize.xml";
        /// <summary>
        /// Получить список текстов
        /// </summary>
        /// <returns></returns>
        public List<string> GetTexts()
        {
            return new List<string> {
                "ГДЕ ЭМОЦИИ,\nТАМ COCA-COLA",
                "ГДЕ ТЫ,\nТАМ COCA-COLA",
                "ГДЕ COCA-COLA,\nТАМ МУЗЫКА",
                "ГДЕ COCA-COLA,\nТАМ МУЗЫКА2",
                "ГДЕ COCA-COLA,\nТАМ МУЗЫКА3",
            };
        }
        /// <summary>
        /// Получить логотипы
        /// </summary>
        /// <returns></returns>
        public List<TshortImage> GetLogos()
        {
            return new List<TshortImage> {
                new TshortImage {
                    Id=1,
                    ImageSrc = "pack://Application:,,,/Resources/men_tshort.png"
                },
                new TshortImage {
                    Id=1,
                    ImageSrc = "pack://Application:,,,/Resources/logo_tshort_2.png"
                },
            };
        }
        /// <summary>
        /// Получить список размеров
        /// </summary>
        /// <returns></returns>
        public List<TshortType> GetTypes()
        {

            var menSizes = new List<TshortSize>();
            var womenSizes = new List<TshortSize>();

            //мужские размеры
            menSizes =  GetSizes(_menPath);
            //женские размеры
            womenSizes= GetSizes(_womenPath);
            var types = new List<TshortType>();
            if (menSizes.Count > 0)
            {
                types.Add(new TshortType
                {
                    Id = 1,
                    ImageSrc = "pack://Application:,,,/Resources/men_tshort.png",
                    Size = menSizes,
                    Label = "Мужская"
                });
            }
            if (womenSizes.Count > 0)
            {
                types.Add(new TshortType
                {
                    Id = 2,
                    ImageSrc = "pack://Application:,,,/Resources/women_tshort.png",
                    Size = womenSizes,
                    Label = "Женская"
                });
            }
            return types;
        }
        private List<TshortSize> GetSizes(string path)
        {
            var serializer = new XmlSerializer(typeof(List<TshortSize>));
            if (File.Exists(path))
            {
                using (var s = File.OpenRead(path))
                {
                    return (List<TshortSize>)serializer.Deserialize(s);
                    
                }
            }
            else
            {
                var defaultSizes = new List<TshortSize>()
                                    {
                                            new TshortSize {
                                                                Count= 1,
                                                                Name="XXS"
                                                            },
                                            new TshortSize {
                                                                Count= 1,
                                                                Name="XS"
                                                            },

                                            new TshortSize {
                                                                Count= 1,
                                                                Name="S"
                                                            },
                                            new TshortSize {
                                                                Count= 1,
                                                                Name="M"
                                                            },
                                            new TshortSize {
                                                                Count= 1,
                                                                Name="L"
                                                            },
                                            new TshortSize {
                                                                Count= 1,
                                                                Name="XL"
                                                            },
                                            new TshortSize {
                                                                Count= 1,
                                                                Name="XXL"
                                                            },
                                    };
                using (var s = File.Create(path))
                {
                    serializer.Serialize(s, defaultSizes);
                    s.Flush();
                }
                return defaultSizes;
            }
        }
        /// <summary>
        /// получить список цветов
        /// </summary>
        /// <returns></returns>
        public List<TshortImage> GetDesigns()
        {
            return new List<TshortImage> {
                    new TshortImage {
                ImageSrc = "pack://Application:,,,/Resources/design_1.png"},
                    new TshortImage {
                ImageSrc = "pack://Application:,,,/Resources/design_2.png"}
            };
        }
        /// <summary>
        /// Получить номер печати
        /// </summary>
        /// <returns></returns>
        public int GetNextNumberPrint()
        {
            if (!File.Exists("Prints.xml"))
                return 1;
            using (var ms = File.OpenRead("Prints.xml"))
            {
                var list = (List<TshortDto>)new XmlSerializer(typeof(List<TshortDto>)).Deserialize(ms);
                return list.Select(x => x.Id).Max() + 1;
            }
        }

        /// <summary>
        /// Сохранить печать
        /// </summary>
        /// <returns></returns>
        public bool SavePrint(TshortDto tshort)
        {
            try
            {
                List<TshortDto> prints = new List<TshortDto>();
                XmlSerializer serializer;
                //декримент мужских футблок
                serializer = new XmlSerializer(typeof(List<TshortSize>));
                if (tshort.Type.Id == 1)
                {

                    using (var file = File.OpenRead(_menPath))
                    {
                        var deSerializer = (List<TshortSize>)serializer.Deserialize(file);
                        var size = deSerializer.First(x => x.Name == tshort.Size.Name);
                        size.Count--;
                        if (size.Count <= 0)
                            deSerializer.Remove(size);
                        file.Close();
                        using (var fileWrite = File.Create(_menPath))
                        {
                            serializer.Serialize(fileWrite, deSerializer);
                        }
                    }
                }
                //декримент женских футблок
                if (tshort.Type.Id == 2)
                {

                    using (var file = File.OpenRead(_womenPath))
                    {
                        var deSerializer = (List<TshortSize>)serializer.Deserialize(file);
                        var size = deSerializer.First(x => x.Name == tshort.Size.Name);
                        size.Count--;
                        if (size.Count <= 0)
                            deSerializer.Remove(size);
                        file.Close();
                        using (var fileWrite = File.Create(_womenPath))
                        {
                            serializer.Serialize(fileWrite, deSerializer);
                        }
                    }
                }
                serializer = new XmlSerializer(typeof(List<TshortDto>));
                if (File.Exists(_filePath))
                {
                    using (var ms = File.OpenRead(_filePath))
                    {
                        prints = (List<TshortDto>)serializer.Deserialize(ms);
                    }
                }
                prints.Add(tshort);
                using (var file = File.Create(_filePath))
                {
                    serializer.Serialize(file, prints);
                }
                return true;
            }
            catch (Exception ex)
            {
                NLog.LogManager.GetCurrentClassLogger().Error(ex);
                return false;
            }
        }
    }
}
