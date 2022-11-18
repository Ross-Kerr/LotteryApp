using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LotteryApp
{
    internal class LottoFiles
    {

        string filename = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "LottoDraw.xml");

        public void writeTickets(ArrayList myTicketList)
        {
            //Write tickets to xml
            XmlWriter writer = null;

            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Indent = true;
            xmlWriterSettings.OmitXmlDeclaration = true;
            xmlWriterSettings.Encoding = Encoding.UTF8;
            xmlWriterSettings.IndentChars = ("\t");

            writer = XmlWriter.Create(filename, xmlWriterSettings);

            // Write decleration
            writer.WriteStartDocument();

            writer.WriteComment("Start of Lottery XML Storing Tickets");

            //Root Element
            writer.WriteStartElement("LottoProgram");

            foreach(Ticket ticket in myTicketList)
            {
                // each ticket getting written

                writer.WriteStartElement("Ticket");
                writer.WriteElementString("Name", ticket.Name);
                writer.WriteElementString("Phone", ticket.Phone);
                writer.WriteElementString("Ball1", ticket.balls[0].ToString());
                writer.WriteElementString("Ball2", ticket.balls[1].ToString());
                writer.WriteElementString("Ball3", ticket.balls[2].ToString());
                writer.WriteElementString("Ball4", ticket.balls[3].ToString());
                writer.WriteElementString("Ball5", ticket.balls[4].ToString());
                writer.WriteElementString("Ball6", ticket.balls[5].ToString());
                writer.WriteEndElement();


            }

            writer.WriteEndElement(); //end element LOTTO PROGRAM
            writer.WriteEndDocument(); //end the document
            writer.Close(); // close the file

            
        }

        public ArrayList readTicketsFromFile()
        {
            ArrayList myTicketList = new ArrayList();

            if (!File.Exists(filename))
            {
                //if there is no file, send back a new arraylist
                return myTicketList;
            }

            XmlReader reader = null;

            //create the reader
            reader = XmlReader.Create(filename);

            while (reader.ReadToFollowing("Ticket"))
            {
                Ticket t = new Ticket();
                reader.ReadToFollowing("Name");
                t.Name = reader.ReadElementContentAsString();

                reader.ReadToFollowing("Phone");
                t.Phone = reader.ReadElementContentAsString();
                ArrayList balls = new ArrayList();

                reader.ReadToFollowing("Ball1");
                balls.Add(reader.ReadElementContentAsInt());
                reader.ReadToFollowing("Ball2");
                balls.Add(reader.ReadElementContentAsInt());
                reader.ReadToFollowing("Ball3");
                balls.Add(reader.ReadElementContentAsInt());
                reader.ReadToFollowing("Ball4");
                balls.Add(reader.ReadElementContentAsInt());
                reader.ReadToFollowing("Ball5");
                balls.Add(reader.ReadElementContentAsInt());
                reader.ReadToFollowing("Ball6");
                balls.Add(reader.ReadElementContentAsInt());

                t.balls = balls; // add balls to the ticket

                myTicketList.Add(t); //add the ticket to the list of balls
            }

            reader.Close(); //close the file when finished with
            return myTicketList; // return the arraylist
        }


    }

}
