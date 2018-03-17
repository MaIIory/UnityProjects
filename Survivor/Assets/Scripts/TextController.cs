using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextController : MonoBehaviour
{

    public Animator animColorFade;
    public AnimationClip fadeColorAnimationClip;				//Reference to animator which will fade to and from black when starting game.

    private Text _text;
    enum States
    {
        menu,
        cabin_0, door_0, window_0, toolbox_0, cabin_1, toolbox_1, door_1, window_1, freedom, dead_0, //Level1 states
        level_0, boat, level_m1, level_1, empty_cabin, level_2, level_1_aP, level_1_a, empty_cabin_a,
        level_0_a, boat_a, end_a, level_m1_a, level_2_a, level_2_a_1, level_2_a_2, level_2_g, level_1_g,
        level_0_g, boat_g, dead_g, end_g
    };
    States _currentState;
    States _nextState;      //need to be set to switch state with fading

    void Start()
    {
        _text = GetComponent<Text>();
        _currentState = States.menu;
    }

    void Update()
    {

        //Machine state handling
        switch (_currentState)
        {
            //MENU
            case States.menu:
                menu();
                break;
            //LEVEL 1
            case States.cabin_0:
                cabin_0();
                break;
            case States.window_0:
                window_0();
                break;
            case States.door_0:
                door_0();
                break;
            case States.toolbox_0:
                toolbox_0();
                break;
            case States.cabin_1:
                cabin_1();
                break;
            case States.window_1:
                window_1();
                break;
            case States.door_1:
                door_1();
                break;
            case States.toolbox_1:
                toolbox_1();
                break;
            case States.freedom:
                freedom();
                break;
            case States.dead_0:
                dead_0();
                break;
            //LEVEL 2
            case States.level_0:
                level_0();
                break;
            case States.boat:
                boat();
                break;
            case States.level_m1:
                level_m1();
                break;
            case States.level_1:
                level_1();
                break;
            case States.empty_cabin:
                empty_cabin();
                break;
            case States.level_2:
                level_2();
                break;
            case States.level_1_aP:
                level_1_aP();
                break;
            case States.level_1_a:
                level_1_a();
                break;
            case States.empty_cabin_a:
                empty_cabin_a();
                break;
            case States.level_0_a:
                level_0_a();
                break;
            case States.boat_a:
                boat_a();
                break;
            case States.end_a:
                end_a();
                break;
            case States.level_m1_a:
                level_m1_a();
                break;
            case States.level_2_a:
                level_2_a();
                break;
            case States.level_2_a_1:
                level_2_a_1();
                break;
            case States.level_2_a_2:
                level_2_a_2();
                break;
            case States.level_2_g:
                level_2_g();
                break;
            case States.level_1_g:
                level_1_g();
                break;
            case States.level_0_g:
                level_0_g();
                break;
            case States.boat_g:
                boat_g();
                break;
            case States.dead_g:
                dead_g();
                break;
            case States.end_g:
                end_g();
                break;
            default:
                break;
        }
    }

    void SwitchToNextState()
    {
        _currentState = _nextState;
    }


    //=== MACHINE STATES ===
    #region menu
    void menu()
    {
        _text.fontSize = 47;
        _text.text = "\nNaciśnij 'Enter'\naby rozpocząć przygodę.";

        if (Input.GetKeyDown(KeyCode.Return))
        {
            animColorFade.SetTrigger("fade");
            _nextState = States.cabin_0;
            Invoke("SwitchToNextState", fadeColorAnimationClip.length * .5f); //Invoke does not support paramers thus _nextState has to be set
        }
    }
    #endregion

    #region Level1
    void cabin_0()
    {
        _text.fontSize = 28;

        _text.text = "\nOkropny ból przeszywa twoją głowę. Nieprzytomnym wzrokiem rozglądasz się wokół. Wygląda na to, że znajdujesz się w na pokładzie statku. Na zewnątrz, przez okrętowe okno, dostrzegasz wzburzone morze, wdzierające się na pokład - najwyraźniej idziecie na dno. Przed sobą dostrzegasz drzwi, a w kącie metalową skrzynię." +
                     "\n\n\n'O' zbadaj Okno, 'D' zbadaj Drzwi, 'S' otwórz Skrzynię";

        //Terrible headache pierces your head. (...)
        //It seems you are inside of ship cabin. Outside, through
        //the porthole, you can see rough sea, whish is getting into ... - most likely ship is sinking.
        //In front of you see door, 

        if (Input.GetKeyDown(KeyCode.O))
            _currentState = States.window_0;
        else if (Input.GetKeyDown(KeyCode.D))
            _currentState = States.door_0;
        else if (Input.GetKeyDown(KeyCode.S))
            _currentState = States.toolbox_0;
    }

    void window_0()
    {
        _text.text = "Przed sobą widzisz solidne okrętowe okno. Na zewnątrz dostrzegasz płonący pokład oraz porozrzucane ciała, najprawdopodobniej załogi statku. Uświadamiasz sobie również, że kabinę wypełnia swąd spalenizny. Kilka razy uderzasz pięścią w bulaj, ale jedynym efektem jest zdarta skóra na twoich kostkach." +
                     "\n\n\n'W' Wróć";

        if (Input.GetKeyDown(KeyCode.W))
            _currentState = States.cabin_0;
    }

    void door_0()
    {
        _text.text = "Po naciśnięciu klamki nic się dzieje. Przeszywa cię uczucie strachu i paniki. Napierasz na drzwi całym swoim ciężarem i udaję ci się uchylić je na kilka centymetrów - tyle wystarczy aby poczuć mieszaninę morskiego powietrza oraz swądu spalenizny." +
                     "\n\n\n'W' Wróć";

        if (Input.GetKeyDown(KeyCode.W))
            _currentState = States.cabin_0;
    }

    void toolbox_0()
    {
        _text.text = "Po kilku mocniejszych szarpnięciach, udaje ci się uchylić wieko skrzyni. W pośpiechu przeglądasz jej zawartość. Wśród kamizelek ratunkowych, apteczek i innych “zbędnych” rzeczy, znajdujesz pistolet sygnalizacyjny. Jest naładowany - nabój znajduje się w komorze." +
                     "\n\n\n'P' zabierz Pistolet, 'W' Wróć";

        if (Input.GetKeyDown(KeyCode.P))
            _currentState = States.cabin_1;
        else if (Input.GetKeyDown(KeyCode.W))
            _currentState = States.cabin_0;
    }

    void cabin_1()
    {
        _text.text = "Ogień zaczyna wdzierać się do kajuty, a dym coraz bardziej gryzie cię w płuca. Mocno ściskasz pistolet w drżących rękach i czujesz, że jest on twoją ostatnią nadzieją." +
                     "\n\n\n'O' zbadaj Okno, 'D' zbadaj Drzwi, 'S' otwórz Skrzynię";

        if (Input.GetKeyDown(KeyCode.O))
            _currentState = States.window_1;
        else if (Input.GetKeyDown(KeyCode.D))
            _currentState = States.door_1;
        else if (Input.GetKeyDown(KeyCode.S))
            _currentState = States.toolbox_1;
    }

    void window_1()
    {
        _text.text = "Wyciągasz pistolet przed siebie i celujesz w środek okna. Zdajesz sobie sprawę, że jeżeli nie uda ci się go przebić to zapewne spalisz się żywcem. Czujesz jak ręce drżą ci jeszcze bardziej…" +
                     "\n\n\n'S' naciśnij Spust, 'W' Wróć";

        if (Input.GetKeyDown(KeyCode.S))
            _currentState = States.freedom;
        else if (Input.GetKeyDown(KeyCode.W))
            _currentState = States.cabin_1;
    }

    void freedom()
    {
        _text.text = "Okno pęka z ogłuszającym brzękiem. W tej samej chwili niemal słyszysz jak kamień, który spadł ci z serca uderza o podłogę. Bez chwili zwłoki przeskakujesz przez powstały otwór, prosto na półpokład prawej burty. Potykasz się o coś. Kiedy spoglądasz w dół, dostrzegasz dwa puste oczodoły, ziejące pustką. Przeszywa cię mieszanina lęku i przerażenia." +
                     "\n\nNaciśnij 'Enter' aby kontynuować";

        if (Input.GetKeyDown(KeyCode.Return))
        {
            animColorFade.SetTrigger("fade");
            _nextState = States.level_0;
            Invoke("SwitchToNextState", fadeColorAnimationClip.length * .5f);
        }

    }

    void door_1()
    {
        _text.text = "Wyciągasz pistolet przed siebie i celujesz w drzwi. Masz nadzieję, że siła pocisku pozwoli ci się wydostać. Z drugiej strony, strzał w stalowe drzwi okrętowe, wydaje się bardzo ryzykowny. Instynktownie kładziesz palec na spuście." +
                     "\n\n\n'S' naciśnij Spust, 'W' Wróć";

        if (Input.GetKeyDown(KeyCode.S))
            _currentState = States.dead_0;
        else if (Input.GetKeyDown(KeyCode.W))
            _currentState = States.cabin_1;
    }

    void toolbox_1()
    {
        _text.text = "Raz jeszcze przeglądasz zawartość skrzyni. W jednej z apteczek znajdujesz aspirynę. Łykasz jedną tabletkę w nadziei, że to pomoże na koszmarny ból głowy. Nie znajdujesz jednak nic więcej, co mogłoby się przydać w obecnej sytuacji." +
                     "\n\n\n'W' Wróć";

        if (Input.GetKeyDown(KeyCode.W))
            _currentState = States.cabin_1;
    }

    void dead_0()
    {
        _text.text = "Powoli pociągasz za spust. W następnej chwili w kabinie powstaje ogromna kula ognia, która pochłania wszystko wokół. W ułamku sekundy zdążyłeś pomyśleć, że to nie był najlepszy pomysł. Czujesz uderzenie gorąca i zdajesz sobie sprawę, że to koniec…" +
                     "\n\n\nNaciśnij 'Enter' aby zakończyć przygodę";

        if (Input.GetKeyDown(KeyCode.Return))
        {
            animColorFade.SetTrigger("fade");
            _nextState = States.menu;
            Invoke("SwitchToNextState", fadeColorAnimationClip.length * .5f);
        }
    }
    #endregion

    #region Level2

    void level_0()
    {
        _text.text = "Chodnik, na którym stoisz z obu stron kończy się schodami. Jedne prowadzą w górę - w stronę rufy, drugie w dół - w stronę dziobu. Wzdłuż miejsca, w którym się znajdujesz, tuż za relingiem, podwieszona jest łódź ratunkowa. Ta jednak, chwieje się niebezpiecznie, odbijając się od kadłuba statku." +
                     "\n\n\n‘W’ Wskocz do łodzi, ‘G’ idź schodami w Górę, ‘D’ idź schodami w Dół";

        if (Input.GetKeyDown(KeyCode.W))
            _currentState = States.boat;
        else if (Input.GetKeyDown(KeyCode.G))
            _currentState = States.level_1;
        else if (Input.GetKeyDown(KeyCode.D))
            _currentState = States.level_m1;
    }

    void boat()
    {
        _text.text = "Z impetem wskakujesz do chwiejącej się łodzi, omal nie wypadając przy tym za burtę. Naciskasz dźwignię zwalniającą szalupę ale bez żadnego skutku. Najwyraźniej mechanizm jest całkowicie zablokowany. Z całych sił próbujesz poluzować linę ręcznie, ale również bez rezultatu." +
                     "\n\n\n‘W’ Wróć na statek";

        if (Input.GetKeyDown(KeyCode.W))
            _currentState = States.level_0;
    }

    void level_m1()
    {
        _text.text = "Zbiegasz schodami w dół. Zatrzymujesz się gwałtownie przed ziejącą przepaścią. Pozostała część schodów, wraz ze sporym fragmentem kadłuba, po prostu przestała istnieć. Co mogło spowodować tak wielkie zniszczenia? Krztusząc się gryzącym dymem, pomyślałeś, że to musiał być wybuch." +
                     "\n\n\n‘W’ Wróć na wyższy poziom";

        if (Input.GetKeyDown(KeyCode.W))
            _currentState = States.level_0;
    }

    void level_1()
    {
        _text.text = "Widok z góry mrozi ci krew w żyłach - cały pokład, który jeszcze utrzymywał się nad powierzchnią wody jest ogarnięty pożarem. Gdzieniegdzie dostrzegasz kolejne ciała. Twój niepokój wzmaga się jeszcze bardziej. Po lewej dostrzegasz lekko uchylone drzwi do jakiegoś pomieszczenia, a przed sobą kolejne schody w górę. W ostatniej chwili, dostrzegasz toporek strażacki zawieszony na ścianie." +
                     "\n\n\n‘W’ Wróć na niższy poziom, ‘G’ idź schodami w Górę,\n‘P’ wejdź do Pomieszczenia, ‘T’ weź Toporek";

        if (Input.GetKeyDown(KeyCode.W))
            _currentState = States.level_0;
        else if (Input.GetKeyDown(KeyCode.G))
            _currentState = States.level_2;
        else if (Input.GetKeyDown(KeyCode.P))
            _currentState = States.empty_cabin;
        else if (Input.GetKeyDown(KeyCode.T))
            _currentState = States.level_1_aP;
    }

    void empty_cabin()
    {
        _text.text = "Przeciskasz się przez wąski otwór utworzony przez zablokowne drzwi. W kłębach dymu dostrzegasz szafę pancerną zamkniętą na kłódkę. Kilka razy bezskutecznie szarpiesz za uchwyt." +
                     "\n\n\n‘W’ Wróć";

        if (Input.GetKeyDown(KeyCode.W))
            _currentState = States.level_1;
    }

    void level_2()
    {
        _text.text = "Wybiegasz na schody prowadzące na nadbudówkę ale drogę tarasuje ci sterta drewnianych skrzyń. Bez solidnego narzędzia raczej nie usuniesz blokady." +
                     "\n\n\n‘W’ Wróć na niższy poziom";

        if (Input.GetKeyDown(KeyCode.W))
            _currentState = States.level_1;
    }

    void level_1_aP()
    {
        _text.text = "Topór, który ściskasz w rękach w zaskakujący sposób dodał ci pewności siebie. Masz przeczucie, że teraz uwolnisz się z potrzasku." +
                     "\n\n\nNaciśnij 'Enter' aby kontynuować";

        if (Input.GetKeyDown(KeyCode.Return))
        {
            animColorFade.SetTrigger("fade");
            _nextState = States.level_1_a;
            Invoke("SwitchToNextState", fadeColorAnimationClip.length * .5f);
        }
    }

    void level_1_a()
    {
        _text.text = "Widok z góry wciąż jest przygnębiający. Większa część pokładu znajduje się już pod wodą, a ta która utrzymuje się jeszcze na powierzchni jest ogarnięta pożarem. Drzwi bocznego pomieszczenia wciąż pozostają lekko uchylone." +
                     "\n\n\n‘W’ Wróć na niższy poziom, ‘G’ idź schodami w Górę, ‘P’ wejdź do Pomieszczenia";

        if (Input.GetKeyDown(KeyCode.W))
            _currentState = States.level_0_a;
        else if (Input.GetKeyDown(KeyCode.G))
            _currentState = States.level_2_a;
        else if (Input.GetKeyDown(KeyCode.P))
            _currentState = States.empty_cabin_a;
    }

    void empty_cabin_a()
    {
        _text.text = "Przeciskasz się przez wąski otwór utworzony przez zablokowne drzwi. W głębi pomieszczenia stoi pancerna szafa zamknięta na kłódkę. Przy pomocy topora udaje ci się do niej dostać. W środku znajdujesz tylko stertę dokumentów. Pośpiesznie przeglądasz ich zawartość. Twoją uwagę przykuwa kilka stwierdzeń, które powtarzają się najczęściej niemal we wszystkich dokumentach, są to: ‘eksperyment’, ‘ściśle tajne’, ‘niebezpieczny’, ‘szczególne środki bezpieczeństwa’, ‘broń’. Na wielu dokumentach dostrzegasz swój podpis. Czujesz jak statek niebezpiecznie przechyla się w stronę dziobu. Czas ucieka." +
                     "\n‘W’ Wróć";

        if (Input.GetKeyDown(KeyCode.W))
            _currentState = States.level_1_a;
    }

    void level_0_a()
    {
        _text.text = "Ponownie znajdujesz się na chodniku zakończonym schodami w dwóch kierunkach. Łódź ratunkowa wychyla się coraz bardziej niebezpiecznie w stronę morza." +
                     "\n\n\n‘W’ Wskocz do łodzi, ‘G’ idź schodami w Górę, ‘D’ idź schodami w Dół";

        if (Input.GetKeyDown(KeyCode.W))
            _currentState = States.boat_a;
        else if (Input.GetKeyDown(KeyCode.G))
            _currentState = States.level_1_a;
        else if (Input.GetKeyDown(KeyCode.D))
            _currentState = States.level_m1_a;
    }

    void boat_a()
    {
        _text.text = "Nachylenie statku spowodowało, że łódź znajduję się teraz dalej od kadłuba. Bierzesz rozpęd i z hukiem upadasz do wnętrza szalupy. Chwytasz za dźwignię ale mechanizm w dalszym ciągu ani drgnie. Po chwili wahania twoje spojrzenie ląduje na toporze. Z drugiej strony przyszło ci na myśl, że może uda ci się kogoś jeszcze uratować, jeśli zdołasz wrócić na pokład." +
                     "\n\n\n‘T’ użyj Toporu, ‘W’ Wróć na statek";

        if (Input.GetKeyDown(KeyCode.T))
            _currentState = States.end_a;
        else if (Input.GetKeyDown(KeyCode.W))
            _currentState = States.level_0_a;
    }

    void end_a()
    {
        _text.text = "Krótkim ciosem przecinasz zablokowaną linę. Szalupa zaczyna swobodnie opadać w stronę wody. Opada coraz szybciej aż z impetem uderza o taflę wody. Siła uderzenia rzuca cię na dno łodzi i pozbawia przytomności..." +
                      "\n\n\nCiąg dalszy nastąpi..." +
                      "\n\nNaciśnij 'Enter' aby zakończyć przygodę";

        if (Input.GetKeyDown(KeyCode.Return))
        {
            animColorFade.SetTrigger("fade");
            _nextState = States.menu;
            Invoke("SwitchToNextState", fadeColorAnimationClip.length * .5f);
        }
    }

    void level_m1_a()
    {
        _text.text = "Udaje ci się pokonać jedynie kilka schodów, wszystkie kolejne prowadzą bezpośrednio pod wodę. Najwyraźniej statek tonie szybciej niż ci się wcześniej wydawało." +
                     "\n\n\n‘W’ Wróć na wyższy poziom";

        if (Input.GetKeyDown(KeyCode.W))
            _currentState = States.level_0_a;
    }

    void level_2_a()
    {
        _text.text = "Wybiegasz na schody prowadzące na nadbudówkę ale drogę tarasuje ci sterta drewnianych skrzyń." +
                     "\n\n\n‘T’ użyj Toporu, ‘W’ Wróć na niższy poziom";

        if (Input.GetKeyDown(KeyCode.T))
            _currentState = States.level_2_a_1;
        else if (Input.GetKeyDown(KeyCode.W))
            _currentState = States.level_1_a;
    }

    void level_2_a_1()
    {
        _text.text = "Przeciskasz się pomiędzy pozostałościami drewnianych skrzyń i docierasz na taras górnego pokładu. Mocny wiatr powoduje, że musisz trzymać się relingów aby nie wypaść za burtę. Dostrzegasz kilka kolejnych ciał… Jedno z nich jednak przykuwa twoją uwagę - to kobieta, na ciele której nie dostrzegasz znacznych obrażeń. Wydaje ci się również, że jej klatka piersiowa delikatnie się podnosi i opada, ale nie masz pewności, że to coś więcej niż tylko złudzenie." +
                     "\n\n‘Z’ Zbadaj kobietę, ‘W’ Wróć na niższy poziom";

        if (Input.GetKeyDown(KeyCode.Z))
            _currentState = States.level_2_a_2;
        else if (Input.GetKeyDown(KeyCode.W))
            _currentState = States.level_2_a;
    }

    void level_2_a_2()
    {
        _text.text = "Klękasz obok nieprzytomnej kobiety. Choć jej oddech jest płytki i nieregularny to rzeczywiście jest teraz wyraźnie wyczuwalny. Mimo zadrapań, siniaków i rozrzuconych włosów możesz stwierdzić, że na co dzień to musi być kobieta o pięknej urodzie." +
                     "\n\n\n‘P’ Podnieś kobietę, ‘W’ Wróć na niższy poziom";

        if (Input.GetKeyDown(KeyCode.P))
        {
            animColorFade.SetTrigger("fade");
            _nextState = States.level_2_g;
            Invoke("SwitchToNextState", fadeColorAnimationClip.length * .5f);

        }
        else if (Input.GetKeyDown(KeyCode.W))
            _currentState = States.level_2_a;
    }

    void level_2_g()
    {
        _text.text = "Z kobietą na plecach jeszcze trudniej utrzymać ci równowagę na niestabilnym pokładzie. Linki relingów mocno wbijają ci się w dłonie. Kilkadziesiąt dodatkowych kilogramów przypomniało ci o okropnym zmęczeniu i bólu głowy." +
                     "\n\n\n‘W’ Wróć na niższy poziom";

        if (Input.GetKeyDown(KeyCode.W))
            _currentState = States.level_1_g;
    }

    void level_1_g()
    {
        _text.text = "Przestajesz już zwracać uwagę na widok z góry, ale zdajesz sobie sprawę, że większa część pokładu znajduje się już pod wodą. Z dodatkowym bagażem na plecach nie ma mowy o przyciśnięciu się do pomieszczenia z uchylonymi drzwiami." +
                     "\n\n\n‘W’ Wróć na niższy poziom, ‘G’ idź schodami w Górę";

        if (Input.GetKeyDown(KeyCode.W))
            _currentState = States.level_0_g;
        else if (Input.GetKeyDown(KeyCode.G))
            _currentState = States.level_2_g;
    }

    void level_0_g()
    {
        _text.text = "Schody prowadzące w stronę dziobu znajdują się już całkowicie pod wodą. Rufa statku niebezpiecznie uniosła się nad poziom wody zwalając cię z nóg. Ledwo udaje ci się wstać z powrotem na nogi. Łapiesz barierkę i dostrzegasz, że łódź ratunkowa wciąż obija się o burtę." +
                     "\n\n\n‘W’ Wskocz do łodzi, ‘G’ idź schodami w Górę";

        if (Input.GetKeyDown(KeyCode.W))
            _currentState = States.boat_g;
        else if (Input.GetKeyDown(KeyCode.G))
            _currentState = States.level_1_g;
    }

    void boat_g()
    {
        _text.text = "Ostatkiem sił bierzesz rozpęd i wskakujesz do łodzi. Szczelina między szalupą, a statkiem okazała się większa niż oceniłeś to wcześniej, jednak jakimś cudem udaje ci się dolecieć do wnętrza łodzi. Ciężar kobiety spowodował, że rozciągnąłeś się jak długi na dnie łodzi, a siła uderzenia pozbawiła cię powietrza w płucach. Krztusząc się, udało ci się podnieść na kolana i nabrać świeżego powietrza. Jeszcze raz sprawdzasz mechanizm utrzymujący łódź na podnośniku - wciąż ani drgnie. Przyszło ci na myśl, że może uda ci się uratować kogoś jeszcze, jeśli zdołasz wrócić na pokład." +
                     "\n‘W’ Wróć na statek, ‘T’ użyj Toporu aby zwolnić szalupę";

        if (Input.GetKeyDown(KeyCode.W))
            _currentState = States.dead_g;
        else if (Input.GetKeyDown(KeyCode.T))
            _currentState = States.end_g;
    }

    void dead_g()
    {
        _text.text = "Stajesz na skraju łodzi i próbujesz się odbić od krawędzi. W momencie wybicia jednak łodź ucieka ci spod nóg, a ty wpadasz w szczelinę pomiędzy szalupą, a statkiem. Histerycznie wyciągasz ręce próbując złapać się czegokolwiek. Nic jednak nie możesz zrobić. Z impetem uderzasz w kipiącą toń, która utworzyła się wokół tonącego statku. Zdążyłeś jeszcze pomyśleć, że najbardziej żal ci jest nieprzytomnej kobiety, którą pozostawiłeś na łodzi..." +
                     "\n\n\nNaciśnij 'Enter' aby zakończyć przygodę";

        if (Input.GetKeyDown(KeyCode.Return))
        {
            animColorFade.SetTrigger("fade");
            _nextState = States.menu;
            Invoke("SwitchToNextState", fadeColorAnimationClip.length * .5f);
        }
    }

    void end_g()
    {
        _text.text = "Jednym ciosem odcinasz zablokowaną linę. Łódź w zastraszającym tempie zaczyna nabierać prędkości, swobodnie opadając w dół. Aby nie wylecieć z szalupy musisz przytrzymać mocno siebie oraz nieprzytomną kobietę. Wiesz, że uderzenie będzie bardzo silne. Prawie go jednak nie odczułeś. Pewnie dlatego, że w momencie uderzenia straciłeś przytomność." +
                      "\n\nCiąg dalszy nastąpi..." +
                      "\n\nNaciśnij 'Enter' aby zakończyć przygodę";

        if (Input.GetKeyDown(KeyCode.Return))
        {
            animColorFade.SetTrigger("fade");
            _nextState = States.menu;
            Invoke("SwitchToNextState", fadeColorAnimationClip.length * .5f);
        }
    }

    #endregion

}
