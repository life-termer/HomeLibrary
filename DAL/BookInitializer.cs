using HomeLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeLibrary.DAL
{
   /* Code causes a database to be created when needed and loads test data into the new database.*/
    public class BookInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BookContext>
    {
        /*The Seed method takes the database context object as an input parameter, and the code in the 
        method uses that object to add new entities to the database.For each entity type, the code creates 
        a collection of new entities, adds them to the appropriate DbSet property, and then saves the 
        changes to the database.*/
        protected override void Seed(BookContext context)
        {
            var books = new List<Book>
            {
                new Book{Title="Harry Potter and the Sorcerer's Stone",Author="J.K. Rowling",Genre="fantasy",Type="Hardcover",
                Language="English",PublicDate=DateTime.Parse("01-10-1998"),Length=309,Description="Harry Potter spent ten long years living with Mr. and Mrs. Dursley, an aunt and uncle whose outrageous favoritism of their perfectly awful son Dudley leads to some of the most inspired dark comedy since Charlie and the Chocolate Factory. But fortunately for Harry, he's about to be granted a scholarship to a unique boarding school called THE HOGWORTS SCHOOL OF WITCHCRAFT AND WIZARDRY, where he will become a school hero at the game of Quidditch (a kind of aerial soccer played high above the ground on broomsticks), he will make some wonderful friends, and, unfortunately, a few terrible enemies. For although he seems to be getting your run-of-the-mill boarding school experience (well, ok, even that's pretty darn out of the ordinary), Harry Potter has a destiny that he was born to fulfill. A destiny that others would kill to keep him from"},
                new Book{Title="Harry Potter and the Chamber of Secrets",Author="J.K. Rowling",Genre="fantasy",Type="Hardcover",
                Language="English",PublicDate=DateTime.Parse("01-07-1999"),Length=352,Description="The summer after his first year at Hogwarts is worse than ever for Harry Potter. The Dursleys of Privet Drive are more horrible to him than ever before. And just when he thinks the endless summer vacation is over, a creature named Dobby the house-elf shows up issuing a grave warning to Harry not to go back to school or disaster will happen! Of course, Harry has to go back- and he does so in grand style, in a flying-car magicked by his friends Ron and Percy Weasley. But getting back to Hogwarts isn't the cure Harry expects it to be. Almost immediately a student is found turned to stone, and then another. And somehow Harry stands accused. Could Harry Potter be the long-feared heir of Slytherin?Harry and friends Hermione and Fred are stretched to their limits in a desperate fight against Draco Malfoy and his gang, the hideously stuck-up new professor Gilderoy Lockheart, the malevolent owner of the diary of Tom Riddle, giant spiders, and perhaps even...Hagrid!This is the book that proves J.K. Rowling is a talent that's here to stay!" },
                new Book{Title="Harry Potter and the Prisoner of Azkaban",Author="J.K. Rowling",Genre="fantasy",Type="Hardcover",
                Language="English",PublicDate=DateTime.Parse("01-10-1999"),Length=435,Description="For twelve long years, the dread fortress of Azkaban held an infamous prisoner named Sirius Black. Convicted of killing thirteen people with a single curse, he was said to be the heir apparent to the Dark Lord, Voldemort.Now he has escaped, leaving only two clues as to where he might be headed: Harry Potter's defeat of You-Know-Who was Black's downfall as well. And the Azkaban guards heard Black muttering in his sleep, He's at Hogwarts . . . he's at Hogwarts.Harry Potter isn't safe, not even within the walls of his magical school, surrounded by his friends. Because on top of it all, there may well be a traitor in their midst." },
                new Book{Title="Harry Potter and the Goblet of Fire",Author="J.K. Rowling",Genre="fantasy",Type="Hardcover",
                Language="English",PublicDate=DateTime.Parse("01-08-2000"),Length=752,Description="Harry Potter is midway through his training as a wizard and his coming of age. Harry wants to get away from the pernicious Dursleys and go to the International Quidditch Cup. He wants to find out about the mysterious event that's supposed to take place at Hogwarts this year, an event involving two other rival schools of magic, and a competition that hasn't happened for a hundred years. He wants to be a normal, fourteen-year-old wizard. But unfortunately for Harry Potter, he's not normal - even by wizarding standards. And in his case, different can be deadly." },
                new Book{Title="Harry Potter and the Order of the Phoenix",Author="J.K. Rowling",Genre="fantasy",Type="Paperback",
                Language="English",PublicDate=DateTime.Parse("01-07-2003"),Length=896,Description="There is a door at the end of a silent corridor. And it's haunting Harry Potter's dreams. Why else would he be waking in the middle of the night, screaming in terror?It's not just the upcoming O.W.L. exams; a new teacher with a personality like poisoned honey; a venomous, disgruntled house-elf; or even the growing threat of He-Who-Must-Not-Be-Named. Now Harry Potter is faced with the unreliability of the very government of the magical world and the impotence of the authorities at Hogwarts.Despite this (or perhaps because of it), he finds depth and strength in his friends, beyond what even he knew; boundless loyalty; and unbearable sacrifice." },
                new Book{Title="Harry Potter and the Half-Blood Prince",Author="J.K. Rowling",Genre="fantasy",Type="Hardcover",
                Language="English",PublicDate=DateTime.Parse("25-07-2006"),Length=652,Description="The war against Voldemort is not going well; even the Muggles have been affected. Dumbledore is absent from Hogwarts for long stretches of time, and the Order of the Phoenix has already suffered losses.And yet . . . as with all wars, life goes on. Sixth-year students learn to Apparate. Teenagers flirt and fight and fall in love. Harry receives some extraordinary help in Potions from the mysterious Half-Blood Prince. And with Dumbledore's guidance, he seeks out the full, complex story of the boy who became Lord Voldemort -- and thus finds what may be his only vulnerability." },
                new Book{Title="Harry Potter and the Deathly Hallowse",Author="J.K. Rowling",Genre="fantasy",Type="Hardcover",
                Language="English",PublicDate=DateTime.Parse("01-08-2007"),Length=784,Description="As he climbs into the sidecar of Hagrid's motorbike and takes to the skies, leaving Privet Drive for the last time, Harry Potter knows that Lord Voldemort and the Death Eaters are not far behind. The protective charm that has kept Harry safe until now is broken, but he cannot keep hiding. The Dark Lord is breathing fear into everything Harry loves and to stop him Harry will have to find and destroy the remaining Horcruxes. The final battle must begin - Harry must stand and face his enemy..." },
                new Book{Title="The Lord of the Rings: 50th Anniversary, One Vol. Edition",Author="J.R.R. Tolkien",Genre="fantasy",Type="Hardcover",
                Language="English",PublicDate=DateTime.Parse("01-01-2005"),Length=1178,Description="The Lord of the Rings tells of the great quest undertaken by Frodo and the Fellowship of the Ring: Gandalf the Wizard; the hobbits Merry, Pippin, and Sam; Gimli the Dwarf; Legolas the Elf; Boromir of Gondor; and a tall, mysterious stranger called Stride. This edition includes the fiftieth-anniversary fully corrected text setting and an extensive index." }
            };

            /*For each entity type, the code creates a collection of new entities, adds them to the appropriate 
            DbSet property, and then saves the changes to the database.*/
            books.ForEach(s => context.Books.Add(s));
            context.SaveChanges();
        }
    }
}