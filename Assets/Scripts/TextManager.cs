using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.Events;

class Scenario
{
    public string ScenarioID;
    public List<(string, Action)> TextandAction = new List<(string, Action)>();
    public List<string> Texts = new List<string>();
    public List<Option> Options = new List<Option>();
    public string NextScenarioID;
}   

class Option
{
    public string Text;
    public Action Action;
}

public class TextManager : MonoBehaviour
{
    [SerializeField]
    public Text message;
    public Text message1;
    public Text message2;
    public Text message3;

    [SerializeField]
    Transform buttonPanel;

    [SerializeField]
    Button optionButton;
    public List<string> Texts;
    int index = 0;
    public float messageSpeed = 0.2f;

    Scenario currentScenario;
    List<Scenario> scenarios = new List<Scenario>();
    string mesString;

    DateTime realTime;

    string realTimeString;

    //string realTimeString;

    string a = "ああああああ";
    public bool isTextss;
    bool isShow;
    string mesStrings;

    bool isRealTimeContinue;

    public Text dtText;
    public SEManager sm;
    public BGMManager bgmm;
    
    public void GetRealTime()
    {
        var scenario = new Scenario();

        FalseText();
        DateTime dt = DateTime.Now;
        realTimeString = String.Format("{0:yyyy年M月d日 (ddd) HH時mm分ss秒}" + "か・・・・", dt);
        currentScenario.TextandAction.Insert(index+1, (realTimeString, FalseText));
        //dtText.DOText(realTimeString, realTimeString.Length * messageSpeed).SetEase(Ease.Linear);
        //時間が止まった音入れる
    }

    public void RealTimeContinue()
    {
        FalseText();
        isRealTimeContinue = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        IsActionText();
        //GetRealTime();
        Scenario scenario01 = new Scenario()
        {
            ScenarioID = "scenario01",
            TextandAction = new List<(string, Action)>()
            {
                ("", Nothing),
                ("午前3時、いつものようにインターネットの波に乗る。\n今夜俺がサーフする波は、怖い話のまとめサイトだ。", ClockSound),
                ("\n\n\n少しビビりなおれは、2chの怖い話集である「洒落怖」を\n1話、また1話と見ていくことにした。", Nothing),
                ("「起承転結がしっかりしていて意外に面白いな」\nそう感心しながら、それでいてビビりながら次々に読み進めていく。", FalseText),
                ("\n\n\n「10年後」というタイトルの怖い話に行きつき、\n男（無職・30歳）が「コレは実際にあった話なのだが、、、」\nと、語り始めるお決まりの冒頭を見る。", Nothing),
                ("長く文字を見過ぎたのもああってか、ここで眠気という別の波に飲み込まれてしまい、俺は寝りについた。", FalseText),
                ("ん、、、んあ〜、寝た寝た。\n気持ちいい目覚めだけど、\nどれくらい寝たんだろ？\nおれは身体をごろんと横に倒し、横においてある日付つきアナログ時計に目をやる。", GetRealTime),
                ("\nなんだよ、、、こんなに寝ちまってたのか、まーいっか。\nそう思い、寝ぼけたままぼんやりと時計を見続けていると、\nふと数字が動いていないことに気づいた。", ClockStop),
                ("ん？まあこの時計、だいぶ長く使ってるし、壊れちゃったかな。\nいや〜でも、電池交換したのは、1週間前くらいだった・・・", FalseText),
                ("\n\nそんな事を考えながら、2度寝を決行するため仰向けになろうとする。", Nothing),
                ("           \n\n      身体が動かない･･･", FalseText),
                ("\n\n\n\n上半身から身体を倒そうとするも、\n身体はアロンアルファみたいにピタッとベットに張り付いたまま離れない。", Nothing),
                ("時計を直視し、横の態勢でまばたきもできない。", FalseText),
                ("\nあれ、え、あ、まじか。これって「金縛り」？", Nothing),
                ("人生で2回目の金縛りに戸惑う。\nというのも、中学生の頃、同じようなことがあったのだ。", FalseText),
                ("\n\nあれはたしか、中学2年生の夏休み前、\n2年1組の教室に忘れてた本を取りに学校に戻った時のこと…", SwitchClassRoom),
                ("おれは教室に入ると最短ルートで目当ての本を手に取る。\nふと教室を出ようと後ろを見ると、\n\n当時好きだった女子の体操服が教室の片隅に落ちていた。", FalseText),
                ("\n\n\n\n\n誰もいない教室、リスクゼロの状況だったのもあってか、\nなぜか俺はその体操服を手に取ってしまう。", Nothing),
                ("その時、教室に近づく足音が外に聞こえた。", WalkSE),
                ("\n今考えれば何もやましいことはしていない。\n\nだが、中2のおれはパニックと罪悪感でいっぱいだった。\n「え？ヤバイヤバイ」と、\n心臓のドクドク音がやばかったのを今でも鮮明に覚えている。", HeartSE),
                ("パニクっているおれは、\nあろうことかその体操服を自分のカバンにしまい、\nささっと教室のドアを閉めて走り出す。",FalseText),
                ("\n\n\n\nあとはひたすら全速力で、息を切らしながら家に帰ったのだった。", RunSE),
                ("次の日、可愛くてクラスでも人気者の女の子の体操服がなくなったこともあり、\nクラスでは少し話題になっていた。", FalseText),
                ("しかしビビリのおれは、「言ったらどう思われるか」ばかりを気にして、\n自分が体操服を盗んだことは言い出せなかった。", FalseText),
                ("\n\n\nそう、盗ってしまってから2日後の夜だ、金縛りに遭ったのは。", Nothing),
                ("その時は夜遅くに起きてしまった。\n起きた瞬間、金縛りになっていたおれは、\n知らない人が体の上に乗ってきて窒息しそうになったのを鮮明に覚えている。", FalseText),
                ("\n\n\n\n・・・声も出せない恐怖\n1分後には何事もなかったようにいつもの状況に戻っていたが、\nあの恐ろしさは忘れられない。", SwitchHome),
                ("ひたすらに冷や汗をかいていた人生はじめての金縛りを思い出す。\nしかし、これはその「金縛り」とは違う。\nあまりに違いすぎる。", FalseText),
                ("\n\n\n\n金縛りは、、、、、          \nこんなに長くない", Nothing),
                ("金縛りは通常2,3分、長くても30分。", FalseText),
                ("\nそれに対して、時計が止まっているから正確にはわからないが、\nもう動けなくなってから3時間は経っているだろう。", Nothing),
                ("ヤバイ、ヤバイ、ヤバイ、、、\nもう一度寝ることも、声を出すことも、\n身体を1ミリ動かすことも、できない。", FalseText),
                ("\n\n\n時計を見て目が開いた状態のまま...", Nothing),
                ("そうだ、これは夢だ！\n確か「明晰夢」っていうやつ。\n夢であることを自覚できる夢、\nコントロールできる夢なんじゃあないか。そうおれは考えた。", FalseText),
                ("\n\n\n\n明晰夢なら自分で覚めることだってできるはず。\n「ハッ、覚めろ！」と強く念じる。", Nothing),
                ("・・・一向に目覚めない。\n何百回「夢から覚めろ！」\nとワラにもすがる思いで願っても変わらない現状、\n進まない時計。", FalseText),
                ("\n\n\n\n考えたくないが、否が応でもある結論にたどり着いてしまう。", Nothing),
                ("「ただ意識だけがある状態で、時が止まっている」", FalseText),
                ("\n\n嘘だろ、ウソだろ、うそだろ。\nいつまでこの状態なんだ！？\n不安、焦りと怒り、いくつもの感情が同時に襲ってくる。", Nothing),
                ("前の金縛りのように、\n誰かが上に乗ってくるわけでもないひたすらの「無」\nまるで動くことができない5億年ボタンだ。", FalseText),
                ("\n\n\n『5億年』という絶望的な数字が脳裏に浮かび、\nさらに恐怖がこみ上げる。", Nothing),
                ("\n\n\n\n\nこれほど自分の想像力を恨んだことはない。", Nothing),
                ("ザ・ワールド、アレストモメンタム、ヘブンズタイム、いや時間停止モノか？\n「時が止まる」というチート能力を受けている側は、\nこんな気持ちだったのかなどと考えてしまう。", FalseText),
                ("時間が止まっているので、もちろん家族の助けもない。\n他の人も同じような状態になってるのか？\n同じ苦しみを味わっているのか？", FalseText),
                ("\n\n\n考えても仕方のないことを頭の中で反芻し、気持ちを落ち着かせようとする。", Nothing),
                ("もう一生このままか？？\n「無限」という最悪の2文字が頭をよぎった。\n泣きたくなってくるほどの静かな恐怖だった......", FalseText),
                ("24時間後———", FalseText),
                ("\n\nくっ、よりによって、何でこっちのパターンなんだ！\n何も考えられないならまだいい、意識があることが問題なんだよ！", Nothing),
                ("\n\n\n\n誰がこんなことを、おれが何をしたっていうんだ！！\n焦りと恐怖を通り越して、怒りに変わる。", Nothing),
                ("\n\n\n\n\n\n声にならない叫びが脳内を乱反射した...", Nothing),
                ("3日後———", FalseText),
                ("\n\nはあ、はあ、あれから何百時間たった？\nもう時間の感覚もわからない。", Nothing),
                ("\n\n\n\n300時間は経ってるかもしれないな・・・\n頼む、頼む、頼む、何かの奇跡よ起きてくれ！動いてくれ、時計！", Nothing),
                ("1週間後———", FalseText),
                ("\n\nそうだ！次は、一人しりとりだ！\n退屈という名の激痛に耐えかねたおれは、\n暇つぶしゲームを片っ端からためしていた。", Nothing),
                ("\n\n\n\n\nんー、じゃあ。しりとりのりから、りんご、ごりら、ラッパ、、、、、、", Nothing),
                ("1ヶ月後——", FalseText),
                ("\n\nスリジャヤワルダナプラコッテ･･･\n\n                  \n\n亭主の好きな赤烏帽子･･････\n\n・・・流石に飽きたな。\n10時間に一つのペースで続くしりとりに嫌気がさした......", Nothing),
                ("1年後———", FalseText),
                ("\n\n殺してくれ！！！\n意識をなくしてくれーー！！\nいつ覚めるかわからない無という恐怖に、もはや精神は限界だった", Nothing),
                ("誰かやったやつがいるんだろ！解放してくれ！\n頼む、頼むよ、、、\nお願いだ、お願いします、、、\nおれをこの状態から解放してください。", FalseText),
                ("\n\n\n\n解放されるなら、もう、死んでもいい。\nそう思い始めていた......", Nothing),
                ("3年後———", FalseText),
                ("\n\n･････････。\n威勢のいいひとり語りも尽きてきた。", Nothing),
                ("\n\n\n\n\n\n･･･････････････。\n･･････････････････。", Nothing),
                ("5年後———", FalseText),
                ("\n\n･････････。\n････････････？", Nothing),
                ("\n\n\n\n･･･これは、現実なのか？\nいや、そもそもおれは本当にこれまでの人生生きていたのか？", Nothing),
                ("\n\n\n\n\n\n生きていた時の感覚を忘れてしまい、\n自分が生きているのかすら、生きていたのかすら疑ってしまう", Nothing),
                ("胡蝶の夢\nこちょこちょと現実と非現実の境界線をくすぐる。", FalseText),
                ("\n\n\n夢だとしても、この苦痛だけはリアルだ…", Nothing),
                ("10年後———", FalseText),
                ("\n\n一生分考えたんじゃないか、、、\nもう何十年経ったかわからない。\nそう思いつつ、暇つぶしにまた自分の人生を振り返ることにした。", Nothing),
                ("･･････幼稚園、小学生の頃は活発な子どもだった。\nそれがあの中学2年生の体操服事件をきっかけとして、\n罪悪感から自分と周りが信じられなくなり、部屋に引きこもるようになった。", FalseText),
                ("\n\n\n\n高校にも行かず、大学も行かなかった。", Nothing),
                ("\n\n\n\n\n就職もせず、ただインターネットの波に乗り続ける日々。", Nothing),
                ("会うどころか、ラインをする友達もいなくなり、\n30歳の誕生日は、もちろん、誰からも祝われなかった。", FalseText),
                ("\n\nそんなクソみたいな人生を送った\n三十路ニートに突如降りかかった無の悲劇か。", Nothing),
                ("\n\n\n\nもうこれはしょうがないことなのかもな・・・", Nothing),
            },
            
            NextScenarioID = "scenario02"
        };
        
        Scenario scenario02 = new Scenario()
        {
            ScenarioID = "scenario02",
            TextandAction = new List<(string, Action)>()
            {
                ("どちらを選ぶ？", FalseText),
            },

            Options = new List<Option>
            {
                new Option()
                {
                    Text = "過去を反省する",
                    Action = Zange,
                },
                new Option()
                {
                    Text = "現実から逃げ続ける",
                    Action = NoZange,
                }
            }

        };
        Scenario scenario03 = new Scenario()
        {
            ScenarioID = "scenario03",
            TextandAction = new List<(string, Action)>()
            {
                ("これまでのエニート人生の怠惰、\n己の弱さと向き合っていなかったおれの逃げ。", Nothing),
                ("\n\nそれに気づかない、気づいかないふりをしていた自分の弱さ。", Nothing),
                ("あぁ、今さら向き合ってチャラになるわけじゃないけど、", FalseText),
                ("\nこれからは心改めて働きたい。", Nothing),
                ("\n\n親への、そして自分への懺悔を、させてほしい。", Nothing),
                ("男が心から後悔し、自分と向き合い、新たな決意をした時、\n視界の片隅で、なにやら動くものが見えた。", FalseText),
                ("", ClockStop),
                ("(・・・ん、動いてないか！？)\n何が起こったのか、何が動いたのかわからず、\n瞬きをして左手で目を擦った", FalseText),
                ("「え、、、時計が動いてる？」とひとりごちる。\nていうか、これ、瞬きできてる！？喋れてる！", FalseText),
                ("\n\n手も動く、足も動く、頭も、指も、腕も動く", Nothing),
                ("「うお！！？」\n飛び上がった俺はもう一度時計が動いていることを確認し、\nただ一言「うおっしゃああああああ」と、頭を抱えて喜んだ。", FalseText),
                ("人生で初めて1つ買った宝くじが、5億円の当たりだったかのような、\n50mの崖から飛び降りて無傷だったような、\nこの世の真理を一瞬で知ったかのような、\nそんなアドレナリンが全身を貫いた。", FalseText),
                ("嬉しさに酔いしれた後、携帯を見た。\nＳＮＳを見たが、いつものくだらないタイムラインばかりで、\n同じ現象はタイムラインに出て来なかった。", FalseText),
                ("俺だけか、、、\n同時多発だと思っていたおれは少しばっかりしたが、すぐに生の実感が上回った。", FalseText),
                ("\n\n\nまあいい、とりあえず今はこの身体が動く、\n時が進む嬉しさを味わうことにしよう。\nそう思いながら流れるようにパソコンの電源をつけ、怖い話を見ていたことを思い出す。", Nothing),
                ("タイトルは『10年後』\n少し読むと自分と全く同じ状況で、意識ある時間停止を体験する男の話であることに気づく。\nこの男も、詐欺をした罪悪感から逃げ続けたらしい。", FalseText),
                ("\n\n\n\n停止前のおれなら鼻で笑った面白くない構成の話だったが、\n今はただそれが真実であると実感するだけだった。", Nothing),
                ("\n\n", FalseText),
            },

            NextScenarioID = "scenario05"
        };

        Scenario scenario04 = new Scenario()
        {
            ScenarioID = "scenario04",
            TextandAction = new List<(string, Action)>()
            {   
                ("何一つうまくいかない、くだらねえ人生だったな。\n永遠に無をさまようんだ。\nああ、もういい。", Nothing),
                ("そして、死にたいと思っても死ねないので\nーそのうちおれは 考えるのをやめた。", FalseText),
                ("エンド①現状維持", FalseText),
                ("", ToTitle),
            },
        };

        Scenario scenario05 = new Scenario()
        {
            ScenarioID = "scenario05",
            TextandAction = new List<(string, Action)>()
            {
                ("どっちにする？", Nothing),
            },

            Options = new List<Option>
            {
                new Option()
                {
                    Text = "反省を続ける",
                    Action = Hansei,
                },
                new Option()
                {
                    Text = "調子に乗る",
                    Action = NoHansei,
                }
            }
        };
        Scenario scenario06 = new Scenario()
        {
            ScenarioID = "scenario06",
            TextandAction = new List<(string, Action)>()
            {
                ("恐怖の10年間、その反省を活かして今では真面目に働いている。", Nothing),
                ("まあ正直、ここでまた決意が折れるようなことがあれば、\nあの退屈という激痛をまた味わわなくてはいけない、\nそんな気がしたというのもある。", FalseText),
                ("\n\n\nただこうして働いているという現状と行動、\nそれこそが大切なのではないだろうか。", Nothing),
                ("皆さんも気をつけてほしい。\n罪悪感と後悔から目を背け続けることを、", FalseText),
                ("\n\n自分の人生から逃げ続けることを…", Nothing),
                ("", RealTimeContinue),
                ("\n\nエンド②動き始める時間", Nothing),
                ("", ToTitle),
            },

        };
        Scenario scenario07 = new Scenario()
        {
            ScenarioID = "scenario07",
            TextandAction = new List<(string, Action)>()
            {
                ("イヤッッホォォォオオォオウ!\nURYYYYYY!!", Nothing),
                ("\n\n抜けれたわ〜www\nいや〜、ほんとマジで最悪だったわw", Nothing),
                ("なんやねんあれ、もーあんなことがあるんなら、働いても意味ねぇな", FalseText),
                ("反省なんて無駄無駄無駄無駄無駄ァーーーーーツ。\nこれからもこれまで通り、ネットの海を大航海しようかw", FalseText),
                ("\n\n\nおれのネットサーフィンは！！！終わらねェ！！！！\nゼハハハハハハハwww", Nothing),
                ("", ClockStop),
                ("ハハハ、ハハ、ハ、は？", FalseText),
                ("エンド③ヘブンズタイム", FalseText),
                ("", ToTitle),
            },
        };

        scenarios.Add(scenario02);
        scenarios.Add(scenario03);
        scenarios.Add(scenario04);
        scenarios.Add(scenario05);
        scenarios.Add(scenario06);
        scenarios.Add(scenario07);
        SetScenario(scenario01);
    }

    void SetScenario(Scenario scenario)
    {
        currentScenario = scenario;
        
        //if(isTextss){
            mesStrings = currentScenario.TextandAction[0].Item1;
            currentScenario.TextandAction[0].Item2.Invoke();
        // }
        // else{
        //     mesStrings = currentScenario.Texts[0];
        // }
        message.DOText(mesStrings, mesStrings.Length * messageSpeed).SetEase(Ease.Linear);

        if (currentScenario.Options.Count > 0)
        {
            SetNextMessage();
            
        }
    }
    public void TextAction()
    {
        /*
        Debug.Log("abc");
            //messageがTweenしているかどうか
            if (DOTween.IsTweening(message))
            {
                //Tween中なら即終了
                message.text = currentScenario.Texts[index];
                message.DOKill();
            }
            else
            {
                index++;
                message.text = "";
                mesString = currentScenario.Texts[index];
                message.DOText(mesString, mesString.Length * messageSpeed).SetEase(Ease.Linear);
            }

        }
        else
        {*/
        // if (isTextss)
        // {
            //Debug.Log("abcd");
            if (DOTween.IsTweening(message))
            {
                //Tween中なら即終了
                mesStrings = currentScenario.TextandAction[index].Item1;
                message.text = mesStrings;
                message.DOKill();
                
            }
            else if(!DOTween.IsTweening(message))
            {
                //ifでmessagetextがあるとき、的な感じで分けなければならないかも。2回目から改行入れまくって見る
                index++;
            
                message3.text = message2.text;
                message2.text = message1.text;
                message1.text = message.text;
                
                message.text = "";
            
                mesStrings = currentScenario.TextandAction[index].Item1;
                message.DOText(mesStrings, mesStrings.Length * messageSpeed).SetEase(Ease.Linear);
                currentScenario.TextandAction[index].Item2.Invoke();
                Debug.Log("abcde");
            }
        //}
        // else
        // {
        //     if (DOTween.IsTweening(message))
        //     {
        //         //Tween中なら即終了
        //         mesStrings = currentScenario.Texts[index];
        //         message.text = mesStrings;
        //         message.DOKill();

        //     }
        //     else if (!DOTween.IsTweening(message))
        //     {
        //         index++;
        //         message1.text = message.text;
        //         message2.text = message1.text;
        //         message.text = "";
        //         mesStrings = currentScenario.Texts[index];
        //         message.DOText(mesStrings, mesStrings.Length * messageSpeed).SetEase(Ease.Linear);
        //         //currentScenario.TextandAction[index].Item2.Invoke();
        //         //Debug.Log("abcde");
        //     }
        // }
        
        
    }   
    void SetNextMessage()
    {
        if (currentScenario.TextandAction.Count > index + 1)
        {
            TextAction();
            //Text.DOText(text, text.Length * messageSpeed).SetEase(Ease.Linear));
        }
        // else if(currentScenario.Texts.Count > index + 1 && !isTextss)
        // {
        //     TextAction();
        // }
        else
        {
            if (DOTween.IsTweening(message))
            {
                message.text = mesStrings;
                message.DOKill();
                //return;
            }else{
                ExitScenario();
                SetButtons();
            }
        }
    }

    void ExitScenario()
    {

        isTextss = false;
        index = 0;
        if (currentScenario.Options.Count > 0)
        {
            
        }
        else
        {
            message.text = "";
            //message.text = mesStrings;
            //message.DOKill();

            Scenario nextScenario = null;

            foreach (Scenario scenario in scenarios)
            {
                if (scenario.ScenarioID == currentScenario.NextScenarioID)
                {
                    nextScenario = scenario;
                }
            }

            if (nextScenario != null)
            {
                SetScenario(nextScenario);
                //GetRealTime();
                //Debug.Log(realTimeString);
            }
            else
            {
                //SceneManager.LoadScene("Game2");
                currentScenario = null;
            }
        }
    }

    void SetButtons()
    {
        foreach (Option o in currentScenario.Options)
        {
            Button b = Instantiate(optionButton);
            Text text = b.GetComponentInChildren<Text>();
            text.text = o.Text;
            b.onClick.AddListener(() => o.Action());
            b.onClick.AddListener(() => ClearButtons());
            b.transform.SetParent(buttonPanel, false);
        }
    }

    void ClearButtons()
    {
        foreach (Transform t in buttonPanel)
        {
            Destroy(t.gameObject);
        }
    }

    public void Zange()
    {
        var scenario = new Scenario();
        scenario.NextScenarioID = "scenario03";
        scenario.TextandAction.Add(("そうだな。。。これは自業自得なのかもしれない。", FalseText));
        SetScenario(scenario);
        Debug.Log("zange");
    }
    public void NoZange()
    {
        var scenario = new Scenario();
        scenario.NextScenarioID = "scenario04";
        scenario.TextandAction.Add(("はあ、もうこんな過去のことを考えても仕方ないか。\n何をしても現状が変わるわけじゃないし。", FalseText));
        SetScenario(scenario);
        Debug.Log("NoZange");
    }
    public void Hansei()
    {
        var scenario = new Scenario();
        scenario.NextScenarioID = "scenario06";
        scenario.TextandAction.Add(("こんにちは、仕事\n俺はこれを機に決意を固め、\n職を見つけて新たな人生を歩むことになった。", FalseText));
        SetScenario(scenario);
        Debug.Log("Hansei");
    }
    public void NoHansei()
    {
        var scenario = new Scenario();
        scenario.NextScenarioID = "scenario07";
        scenario.TextandAction.Add(("ふぅ、、、落ち着いたおれは、背筋をグイッと伸ばす。", FalseText));
        SetScenario(scenario);
        Debug.Log("NoHansei");
    }

    public void Nothing()
    {
        Debug.Log("Nothing");
    }
    public void IsActionText()
    {
        isTextss  = true;
        Debug.Log(isTextss);
    }
    // public void StopDotween()
    // {
    //     dtText.text = realTimeString;
    //     dtText.DOKill();
    // }
    public void FalseText()
    {
        dtText.text = "";
        message3.text = "";
        message2.text = "";
        message1.text = "";
        message.text = "";
    }

    public void RunSE ()
    {
        sm.RunSE();
    }

    public void HeartSE()
    {
        sm.HeartSE();
    }

    public void SwitchClassRoom()
    {
        
    }
    public void SwitchHome()
    {

    }
    public void WalkSE()
    {
        FalseText();
        sm.WalkSE();
    }

    public void ClockSound()
    {
        FalseText();
        bgmm.ClockSound();
    }
    public void ClockStop()
    {
        bgmm.ClockStop();
    }
    public void ToTitle()
    {
        FadeManager.Instance.LoadScene("Game1", 0.3f);
    }


    // Update is called once per frame
    void Update()
    {
        if (currentScenario != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (buttonPanel.GetComponentsInChildren<Button>().Length < 1)
                {
                    SetNextMessage();
                }
            }
        }
        if(isRealTimeContinue)
        {
            DateTime dt = DateTime.Now;
            realTimeString = String.Format("{0:yyyy年M月d日 (ddd) HH時mm分ss秒}", dt);
            Debug.Log(realTimeString);
            //dtText.DOText(realTimeString, realTimeString.Length * messageSpeed).SetEase(Ease.Linear);
            dtText.text = realTimeString;
            
        }


    }
}
