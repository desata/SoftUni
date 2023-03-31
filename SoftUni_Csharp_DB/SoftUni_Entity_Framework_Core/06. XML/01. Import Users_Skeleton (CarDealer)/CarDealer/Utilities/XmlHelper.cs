using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Utilities;

public  class XmlHelper
{
    public T Deserialize<T>(string inputXml, string rootName)
    {
        XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T),xmlRoot);

       using  StringReader reader = new StringReader(inputXml);
        T deserializedDto = (T)xmlSerializer.Deserialize(reader);

        return deserializedDto;
    }
    //May Not be used - for Collection
    public IEnumerable<T> DeserializeCollection<T>(string inputXml, string rootName)
    {
        XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

        StreamReader reader = new StreamReader(inputXml);
        T[] supplierDtos = (T[])xmlSerializer.Deserialize(reader);

        return supplierDtos;
    }
    //Serialize<ExportDto[]>(ExportDto[], rootName)
    //Serialize<ExportDto>(ExportDto, rootName)
    public string Serialize<T>(T obj,string rootName)
    {

        StringBuilder result = new StringBuilder();

        XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(); // with this we remove the namespaces in root

        namespaces.Add(string.Empty, string.Empty); //i.e adding preffix empty string and namespace empty string

        using StringWriter writer = new StringWriter(result);// this writer will be write in result instead(вместо) us

        xmlSerializer.Serialize(writer, obj, namespaces);


        return result.ToString().TrimEnd();
    }

    
// May not be use - Serialize<ExportDto>(ExportDto[], rootName)-syntaxis sugar
    public string Serialize<T>(T[] obj, string rootName)
    {
        StringBuilder sb = new StringBuilder();

        XmlRootAttribute xmlRoot =
            new XmlRootAttribute(rootName);
        XmlSerializer xmlSerializer =
            new XmlSerializer(typeof(T[]), xmlRoot);

        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
        namespaces.Add(string.Empty, string.Empty);

        using StringWriter writer = new StringWriter(sb);
        xmlSerializer.Serialize(writer, obj, namespaces);

        return sb.ToString().TrimEnd();
    }
}
