﻿using GroupDocs.Assembly;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunReportXML
{
    public class Program
    {
        public const string customerXMLfile = "../../../Samples/Customers.xml";
        static void Main(string[] args)
        {
            //ExStart:GenerateBulletedListFromXMLinOpenPresentationFormat
            //Setting up source open presentation template
            FileStream template = File.OpenRead("../../../Samples/Single Row.docx");
            //Setting up destination open presentation report 
            FileStream output = File.Create("../../../Samples/Xml Single Row.docx");

            try
            {
                //Instantiate DocumentAssembler class
                DocumentAssembler assembler = new DocumentAssembler();
                //Call AssembleDocument to generate Bulleted List Report in open presentation format
                assembler.AssembleDocument(template, output, GetSingleRow(), "customer");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //ExEnd:GenerateBulletedListFromXMLinOpenPresentationFormat
        }
        public static DataRow GetSingleRow()
        {
            try
            {
                DataSet singleCustomer = new DataSet();

                FileStream readProductXML = new FileStream(customerXMLfile, FileMode.Open);
                singleCustomer.ReadXml(readProductXML, XmlReadMode.ReadSchema);
                singleCustomer.Tables[0].TableName = "Customers";

                return singleCustomer.Tables["Customers"].Rows[0];
            }
            catch
            {
                return null;
            }
        }
    }
}
