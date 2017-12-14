using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using YamlDotNet.RepresentationModel;

namespace YamlDotNet.Samples
{
    public class LoadYamlStream
    {
        public static void Main(string[] args)
        {
            if (args.Length <= 1)
            {
                usage();
            }else if (args.Length == 2 & args[0] =="-f")
            {
                readYaml(args[1]);
            }
            else
            {
                usage();
            }            
        }
        static void useHead()
        {
            Console.WriteLine("Blue Ocean Software Yaml Tool 1.0.0.0 版");
            Console.WriteLine("Copyright (C) Blue Ocean Software Corporation.");
            Console.WriteLine("All Rights Reserved.");
            Console.WriteLine();
        }
        static void usage()
        {
            useHead();
            Console.WriteLine("Usage: iasl [Options] [File]");
            Console.WriteLine("YamlRead -h                  This help");
            Console.WriteLine("YamlRead -f File_Path        Parsing Yaml file");
            Console.WriteLine();
        }
        static void readYaml(string file_path)
        {
            useHead();
            // string file_path = "..\\..\\config.yml";
            // Setup the input
            if (File.Exists(@file_path) == false)
            {
                Console.WriteLine("Warning[0001]:The Yaml file is not exist:{0}", file_path);
            }
            else
            {
                var input = new StreamReader(file_path, Encoding.Default);
                // Load the stream
                var yaml = new YamlStream();
                yaml.Load(input);
                // Examine the stream
                var mapping = (YamlMappingNode)yaml.Documents[0].RootNode;
                foreach (var entry in mapping.Children)
                {
                    Console.WriteLine(((YamlScalarNode)entry.Key).Value);
                }
                // List all the items
                //var items = (YamlSequenceNode)mapping.Children[new YamlScalarNode("items")];
                //foreach (YamlMappingNode item in items)
                //{
                //    Console.WriteLine(item.Children.Keys.ToString());
                //}
            }                
        }
    }
}