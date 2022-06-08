using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database {
    // Start is called before the first frame update

    public class Item {
        public string text = "Untiteled";
        public string beschrijving = "Beschrijving";
        public int matId = 0;
        public int innerMatId= 0; 
        /// materiallijst
        /// 0 = Kernwaarde
        /// 1 = design thinking
        /// 2 = Library
        /// 3 = Field
        /// 4 = Lab
        /// 5 = Showroom
        /// 6 = Workshop
        /// 7 = stepping stone
        /// 8 = Deelvragen
    }

    public static Dictionary<int, Item> data = new Dictionary<int, Item> {
        {1, new Item{text="Danken", matId=0 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {2, new Item{text="Dansen", matId=0 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {3, new Item{text="Delen", matId=0 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {4, new Item{text="Denken", matId = 0 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {5, new Item{text="Dichten", matId=0 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {6, new Item{text="Dromen", matId=0 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {7, new Item{text="Durven", matId=0 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {8, new Item{text="Empathize", matId = 1 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {9, new Item{text="Define", matId = 1 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {10, new Item{text="Ideate", matId = 1 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {11, new Item{text="Prototype", matId = 1 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {12, new Item{text="Testen", matId = 1 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {13, new Item{text="Implementing", matId = 1 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {14, new Item{text="Benchmark creation", matId = 2 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {15, new Item{text="Best, good & bad practices", matId = 2 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {16, new Item{text="Competitive Analysis", matId = 2 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {17, new Item{text="Design pattern search", matId = 2 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {18, new Item{text="Expert interview", matId = 2 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {19, new Item{text="Literature study", matId = 2 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {20, new Item{text="Trend Analysis", matId = 2 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {21, new Item{text="Bag tour", matId = 3 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {22, new Item{text="Card sorting", matId = 3 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {23, new Item{text="Context mapping", matId = 3 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {24, new Item{text="Cultural probes", matId = 3 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {25, new Item{text="Day in the life", matId = 3 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {26, new Item{text="Diary study", matId = 3 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {27, new Item{text="Fly on the wall", matId = 3 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {28, new Item{text="Focus group", matId = 3 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {29, new Item{text="Interview", matId = 3 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {30, new Item{text="Participant observation", matId = 3 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {31, new Item{text="Survey", matId = 3 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {32, new Item{text="A/B testing", matId = 4 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {33, new Item{text="Biometrics", matId = 4 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {34, new Item{text="Field trial", matId = 4 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {35, new Item{text="Online analytics", matId = 4 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {36, new Item{text="Thinking aloud", matId = 4 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {37, new Item{text="usability testing", matId = 4 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {38, new Item{text="Wizard of Oz", matId = 4 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {39, new Item{text="Co-reflection", matId = 5 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {40, new Item{text="Expo", matId = 5 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {41, new Item{text="Heuristic evaluation", matId = 5 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {42, new Item{text="Peer review", matId = 5 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {43, new Item{text="Pitch", matId = 5 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {44, new Item{text="Provocative prototyping", matId = 5 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {45, new Item{text="(Product) Quality review", matId = 5 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {46, new Item{text="USP (unique selling points)", matId = 5 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {47, new Item{text="Co-creation", matId = 6 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {48, new Item{text="Ideation", matId = 6 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {49, new Item{text="Morphological chart", matId = 6 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {50, new Item{text="Proof of concept", matId = 6 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {51, new Item{text="Prototyping", matId = 6 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {52, new Item{text="Scamper", matId = 6 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {53, new Item{text="Sketching", matId = 6 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {54, new Item{text="Storytelling", matId = 6 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {55, new Item{text="Tinkering", matId = 6 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {56, new Item{text="Business model canvas", matId = 7 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {57, new Item{text="Comparison chart", matId = 7 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {58, new Item{text="concept", matId = 7 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {59, new Item{text="Customer Journey", matId = 7 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {60, new Item{text="Design specification", matId = 7 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {61, new Item{text="Empathy map", matId = 7 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {62, new Item{text="Expert review report", matId = 7 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {63, new Item{text="Inspiration wall", matId = 7 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {64, new Item{text="Mood board", matId = 7 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {65, new Item{text="Persona", matId = 7 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {66, new Item{text="Prototype", matId = 7 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {67, new Item{text="Requirement list", matId = 7 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {68, new Item{text="Scenario", matId = 7 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {69, new Item{text="Task Analysis", matId = 7 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {70, new Item{text="Test report", matId = 7 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {71, new Item{text="Deelvraag: Inhoud", matId = 8 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {72, new Item{text="Deelvraag: Doel", matId = 8 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {73, new Item{text="Deelvraag: Huidige situatie", matId = 8 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {74, new Item{text="Deelvraag: Behoefte", matId = 8 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {75, new Item{text="Deelvraag: Werking", matId = 8 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {76, new Item{text="Deelvraag: Uitwerking", matId = 8 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {77, new Item{text="Deelvraag: Ervaring", matId = 8 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {78, new Item{text="Deelvraag: Succes factor", matId = 8 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        {79, new Item{text="Deelvraag: Doel behaald", matId = 8 ,innerMatId= 0, beschrijving = "Dit is de beschrijving"} },
        };

}
