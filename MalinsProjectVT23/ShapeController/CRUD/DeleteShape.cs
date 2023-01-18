﻿using MalinsProjectVT23.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryErrorHandling;
using ClassLibraryStrings;
using Action = ClassLibraryStrings.Action;
using MalinsProjectVT23.Data;
using Microsoft.EntityFrameworkCore;

namespace MalinsProjectVT23.ShapeController.CRUD
{
    public class DeleteShape : ICrudShape
    {
        public DeleteShape(ApplicationDbContext dbContext, ReadShape readShape, UpdateShape updateShape)
        {
            DbContext = dbContext;
            Read = readShape;
            Update = updateShape;
        }

        public ApplicationDbContext DbContext { get; set; }
        public ReadShape Read { get; set; }
        public UpdateShape Update { get; set; }

        public void RunCrud(IShape shape)
        {
            Console.Clear();
            if (!DbContext.ShapeResults.Where(s => s.Shape.Name == shape.Name)
                    .Include(s => s.Shape)
                    .Any())
            {
                Read.ListOfShapeIsEmpty(shape);
            }
            else if (DbContext.ShapeResults.Any())
            {
                Read.View(shape);
                Line.LineOneHyphen();
                Action.Yellow(" Select shape by Id \n ");
                var shapeFound = Update.FindShapeById(shape);
                Update.ShowChosenShape();

                var userInputDelete = AskIfDeleteShape();

                if (userInputDelete.ToUpper() == "Y")
                {
                    DbContext.ShapeResults.Remove(shapeFound);
                    DbContext.SaveChanges();
                    Action.Successful(" Shape deleted");
                    Action.PressEnterToContinue();
                }
                else
                {
                    Action.Yellow(" Shape not deleted");
                    Action.PressEnterToContinue();
                }
            }
        }

        private static string? AskIfDeleteShape()
        {
            Action.Red("\n\n Delete shape? Press");
            Action.White(" Y");
            Action.Red(" to delete.\n" + " Press any other key to continue without deleting shape.\n");
            Action.White(" Write input: ");
            var userInputDelete = Console.ReadLine();
            return userInputDelete;
        }
    }
}
