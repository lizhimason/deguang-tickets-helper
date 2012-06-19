using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;
using DeGuangTicketsHelper.Entity;
using System.Diagnostics;
using System.Net;
using System.Web;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace DeGuangTicketsHelper
{
    public partial class frmTicketQuery : Form
    {
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool InternetSetCookie(string lpszUrlName, string lbszCookieName, string lpszCookieData);

        private static string stations;
        #region 车站信息
        private static string stations_buffer="@bjb|北京北|VAP|0" +
                            "@bji|北京|BJP|1" +
                            "@bjn|北京南|VNP|2" +
                            "@bjx|北京西|BXP|3" +
                            "@cqb|重庆北|CUW|4" +
                            "@cqi|重庆|CQW|5" +
                            "@sha|上海|SHH|6" +
                            "@shn|上海南|SNH|7" +
                            "@shq|上海虹桥|AOH|8" +
                            "@shx|上海西|SXH|9" +
                            "@tjb|天津北|TBP|10" +
                            "@tji|天津|TJP|11" +
                            "@tjn|天津南|TIP|12" +
                            "@tjx|天津西|TXP|13" +
                            "@cch|长春|CCT|14" +
                            "@cdd|成都东|ICW|15" +
                            "@cdu|成都|CDW|16" +
                            "@csh|长沙|CSQ|17" +
                            "@csn|长沙南|CWQ|18" +
                            "@fzh|福州|FZS|19" +
                            "@fzn|福州南|FYS|20" +
                            "@gya|贵阳|GIW|21" +
                            "@gzb|广州北|GBQ|22" +
                            "@gzd|广州东|GGQ|23" +
                            "@gzh|广州|GZQ|24" +
                            "@gzn|广州南|IZQ|25" +
                            "@heb|哈尔滨|HBB|26" +
                            "@hed|哈尔滨东|VBB|27" +
                            "@hfe|合肥|HFH|28" +
                            "@hfx|合肥西|HTH|29" +
                            "@hhd|呼和浩特东|NDC|30" +
                            "@hht|呼和浩特|HHC|31" +
                            "@hkd|海口东|HMQ|32" +
                            "@hko|海口|VUQ|33" +
                            "@hzh|杭州|HZH|34" +
                            "@hzn|杭州南|XHH|35" +
                            "@jna|济南|JNK|36" +
                            "@jnd|济南东|JAK|37" +
                            "@jnx|济南西|JGK|38" +
                            "@kmi|昆明|KMM|39" +
                            "@lsa|拉萨|LSO|40" +
                            "@lzh|兰州|LZJ|41" +
                            "@lzx|兰州西|LAJ|42" +
                            "@nch|南昌|NCG|43" +
                            "@nji|南京|NJH|44" +
                            "@njn|南京南|NKH|45" +
                            "@njx|南京西|NIH|46" +
                            "@nni|南宁|NNZ|47" +
                            "@sjb|石家庄北|VVP|48" +
                            "@sjz|石家庄|SJP|49" +
                            "@sya|沈阳|SYT|50" +
                            "@syb|沈阳北|SBT|51" +
                            "@syd|沈阳东|SDT|52" +
                            "@tyb|太原北|TBV|53" +
                            "@tyd|太原东|TDV|54" +
                            "@tyu|太原|TYV|55" +
                            "@wha|武汉|WHN|56" +
                            "@wlq|乌鲁木齐|WMR|57" +
                            "@xab|西安北|EAY|58" +
                            "@xan|西安南|CAY|59" +
                            "@xan|西安|XAY|60" +
                            "@xnx|西宁西|XXO|61" +
                            "@ych|银川|YIJ|62" +
                            "@zzh|郑州|ZZF|63" +
                            "@aka|安康|AKY|64" +
                            "@aks|阿克苏|ASR|65" +
                            "@alh|阿里河|AHX|66" +
                            "@api|安平|APT|67" +
                            "@aqi|安庆|AQH|68" +
                            "@ash|鞍山|AST|69" +
                            "@ash|安顺|ASW|70" +
                            "@aya|安阳|AYF|71" +
                            "@ban|北安|BAB|72" +
                            "@bbu|蚌埠|BBH|73" +
                            "@bch|白城|BCT|74" +
                            "@bha|北海|BHZ|75" +
                            "@bhe|白河|BEL|76" +
                            "@bji|滨江|BJB|77" +
                            "@bji|白涧|BAP|78" +
                            "@bji|宝鸡|BJY|79" +
                            "@bkt|博克图|BKX|80" +
                            "@bse|百色|BIZ|81" +
                            "@bss|白山市|HJL|82" +
                            "@btd|包头东|BDC|83" +
                            "@bto|包头|BTC|84" +
                            "@btz|北屯镇|BXR|85" +
                            "@bxi|本溪|BXT|86" +
                            "@byx|白银西|BXJ|87" +
                            "@bzh|亳州|BZH|88" +
                            "@cbi|赤壁|CBN|89" +
                            "@cde|承德|CDP|90" +
                            "@cde|常德|VGQ|91" +
                            "@cfe|赤峰|CFD|92" +
                            "@cna|苍南|CEH|93" +
                            "@ctu|昌图|CTT|94" +
                            "@cxi|楚雄|COM|95" +
                            "@cxi|曹县|CXK|96" +
                            "@czb|长治北|CBF|97" +
                            "@czh|长治|CZF|98" +
                            "@czh|池州|IYH|99" +
                            "@czh|郴州|CZQ|100" +
                            "@czh|沧州|COP|101" +
                            "@czh|常州|CZH|102" +
                            "@czu|崇左|CZZ|103" +
                            "@dab|大安北|RNT|104" +
                            "@ddo|丹东|DUT|105" +
                            "@dfh|东方红|DFB|106" +
                            "@dgd|东莞东|DMQ|107" +
                            "@dhs|大虎山|DHD|108" +
                            "@dhu|敦化|DHL|109" +
                            "@dhu|敦煌|DHJ|110" +
                            "@dhu|德惠|DHT|111" +
                            "@djy|都江堰|DDW|112" +
                            "@dli|大理|DKM|113" +
                            "@dli|大连|DLT|114" +
                            "@dna|定南|DNG|115" +
                            "@dqi|大庆|DZX|116" +
                            "@dsh|东胜|DOC|117" +
                            "@dsq|大石桥|DQT|118" +
                            "@dto|大同|DTV|119" +
                            "@dyi|东营|DPK|120" +
                            "@dys|大杨树|DUX|121" +
                            "@dyu|都匀|RYW|122" +
                            "@dzh|邓州|DOF|123" +
                            "@dzh|德州|DZP|124" +
                            "@dzh|达州|RXW|125" +
                            "@eli|二连|RLC|126" +
                            "@esh|恩施|ESN|127" +
                            "@fdi|福鼎|FES|128" +
                            "@fld|风陵渡|FLV|129" +
                            "@fli|涪陵|FLW|130" +
                            "@flj|富拉尔基|FRX|131" +
                            "@fsb|抚顺北|FET|132" +
                            "@fsh|佛山|FSQ|133" +
                            "@fxi|阜新|FXD|134" +
                            "@fya|阜阳|FYH|135" +
                            "@gem|格尔木|GRO|136" +
                            "@gha|广汉|GHW|137" +
                            "@glb|桂林北|GBZ|138" +
                            "@gli|桂林|GLZ|139" +
                            "@gqi|高崎|XBS|140" +
                            "@gsh|固始|GXN|141" +
                            "@gsh|广水|GSN|142" +
                            "@gyu|广元|GYW|143" +
                            "@gzh|赣州|GZG|144" +
                            "@gzl|公主岭|GLT|145" +
                            "@han|淮安|AUH|146" +
                            "@hbe|鹤北|HMB|147" +
                            "@hbe|淮北|HRH|148" +
                            "@hbi|淮滨|HVN|149" +
                            "@hch|潢川|KCN|150" +
                            "@hda|邯郸|HDP|151" +
                            "@hdz|横道河子|HDB|152" +
                            "@hga|鹤岗|HGB|153" +
                            "@hgt|皇姑屯|HTT|154" +
                            "@hgu|红果|HEM|155" +
                            "@hhu|怀化|HHQ|156" +
                            "@hko|汉口|HKN|157" +
                            "@hld|葫芦岛|HLD|158" +
                            "@hle|海拉尔|HRX|159" +
                            "@hll|霍林郭勒|HWD|160" +
                            "@hlu|海伦|HLB|161" +
                            "@hma|侯马|HMV|162" +
                            "@hmi|哈密|HMR|163" +
                            "@hna|桦南|HNB|164" +
                            "@hna|淮南|HAH|165" +
                            "@hnx|海宁西|EUH|166" +
                            "@hrb|怀柔北|HBP|167" +
                            "@hro|怀柔|HRP|168" +
                            "@hsd|黄石东|OSN|169" +
                            "@hsh|黄山|HKH|170" +
                            "@hsh|华山|HSY|171" +
                            "@hsh|衡水|HSP|172" +
                            "@hsh|黄石|HSN|173" +
                            "@hya|衡阳|HYQ|174" +
                            "@hze|菏泽|HIK|175" +
                            "@hzh|贺州|HXZ|176" +
                            "@hzh|汉中|HOY|177" +
                            "@hzh|惠州|HCQ|178" +
                            "@jan|吉安|VAG|179" +
                            "@jch|晋城|JCF|180" +
                            "@jcj|金城江|JJZ|181" +
                            "@jdz|景德镇|JCG|182" +
                            "@jgq|加格达奇|JGX|183" +
                            "@jgs|井冈山|JGG|184" +
                            "@jhe|蛟河|JHL|185" +
                            "@jhn|金华南|RNH|186" +
                            "@jhx|金华西|JBH|187" +
                            "@jji|九江|JJG|188" +
                            "@jli|吉林|JLL|189" +
                            "@jlo|九龙|JQO|190" +
                            "@jme|荆门|JMN|191" +
                            "@jms|佳木斯|JMB|192" +
                            "@jni|济宁|JIK|193" +
                            "@jnn|集宁南|JAC|194" +
                            "@jqu|酒泉|JQJ|195" +
                            "@jsh|吉首|JIQ|196" +
                            "@jsh|江山|JUH|197" +
                            "@jta|九台|JTL|198" +
                            "@jxi|鸡西|JXB|199" +
                            "@jxx|绩溪县|JRH|200" +
                            "@jyg|嘉峪关|JGJ|201" +
                            "@jyo|江油|JFW|202" +
                            "@jzh|锦州|JZD|203" +
                            "@jzh|金州|JZT|204" +
                            "@kel|库尔勒|KLR|205" +
                            "@kfe|开封|KFF|206" +
                            "@kli|凯里|KLW|207" +
                            "@ksh|喀什|KSR|208" +
                            "@ksn|昆山南|KNH|209" +
                            "@ktu|奎屯|KTR|210" +
                            "@kyu|开原|KYT|211" +
                            "@lan|六安|UAH|212" +
                            "@lba|灵宝|LBF|213" +
                            "@lcg|芦潮港|UCH|214" +
                            "@lch|陆川|LKZ|215" +
                            "@lch|隆昌|LCW|216" +
                            "@lch|利川|LCN|217" +
                            "@ldi|娄底|LDQ|218" +
                            "@lfe|临汾|LFV|219" +
                            "@lhe|临河|LHC|220" +
                            "@lhe|漯河|LON|221" +
                            "@lhu|隆化|UHP|222" +
                            "@lji|龙井|LJL|223" +
                            "@lji|丽江|LHM|224" +
                            "@ljy|龙家营|LKP|225" +
                            "@lli|吕梁|LHV|226" +
                            "@lli|醴陵|LLG|227" +
                            "@lpi|滦平|UPP|228" +
                            "@lps|六盘水|UMW|229" +
                            "@lqi|灵丘|LVV|230" +
                            "@lsh|旅顺|LST|231" +
                            "@lxi|兰溪|LWH|232" +
                            "@lxi|澧县|LEQ|233" +
                            "@lxi|陇西|LXJ|234" +
                            "@lya|龙岩|LYS|235" +
                            "@lya|耒阳|LYQ|236" +
                            "@lya|洛阳|LYF|237" +
                            "@lyd|连云港东|UKH|238" +
                            "@lyd|洛阳东|LDF|239" +
                            "@lyi|临沂|LVK|240" +
                            "@lym|洛阳龙门|LLF|241" +
                            "@lyu|辽源|LYL|242" +
                            "@lyu|凌源|LYD|243" +
                            "@lyu|柳园|DHR|244" +
                            "@lzh|柳州|LZZ|245" +
                            "@lzh|辽中|LZD|246" +
                            "@mch|麻城|MCN|247" +
                            "@mdh|免渡河|MDX|248" +
                            "@mdj|牡丹江|MDB|249" +
                            "@mgu|明光|MGH|250" +
                            "@mhe|漠河|MVX|251" +
                            "@mmd|茂名东|MDQ|252" +
                            "@mmi|茂名|MMZ|253" +
                            "@msh|密山|MSB|254" +
                            "@mwe|麻尾|VAW|255" +
                            "@mya|绵阳|MYW|256" +
                            "@mzh|梅州|MOQ|257" +
                            "@mzl|满洲里|MLX|258" +
                            "@nbd|宁波东|NVH|259" +
                            "@nch|南岔|NCB|260" +
                            "@nch|南充|NCW|261" +
                            "@nda|南丹|NDZ|262" +
                            "@nfe|南芬|NFT|263" +
                            "@nhe|讷河|NHX|264" +
                            "@nji|内江|NJW|265" +
                            "@nji|嫩江|NGX|266" +
                            "@npi|南平|NPS|267" +
                            "@nto|南通|NUH|268" +
                            "@nya|南阳|NFF|269" +
                            "@nzs|碾子山|NZX|270" +
                            "@pds|平顶山|PEN|271" +
                            "@pji|盘锦|PVD|272" +
                            "@pli|平凉|PIJ|273" +
                            "@psh|坪石|PSQ|274" +
                            "@pxi|凭祥|PXZ|275" +
                            "@pxi|萍乡|PXG|276" +
                            "@pxx|郫县西|PCW|277" +
                            "@pzh|攀枝花|PRW|278" +
                            "@qch|蕲春|QRN|279" +
                            "@qcs|青城山|QSW|280" +
                            "@qda|青岛|QDK|281" +
                            "@qhc|清河城|QYP|282" +
                            "@qji|黔江|QNW|283" +
                            "@qji|曲靖|QJM|284" +
                            "@qqe|齐齐哈尔|QHX|285" +
                            "@qth|七台河|QTB|286" +
                            "@qxi|沁县|QVV|287" +
                            "@qzd|泉州东|QRS|288" +
                            "@qzh|衢州|QEH|289" +
                            "@qzh|泉州|QYS|290" +
                            "@ran|融安|RAZ|291" +
                            "@rji|瑞金|RJG|292" +
                            "@rzh|日照|RZK|293" +
                            "@scp|双城堡|SCB|294" +
                            "@sfh|绥芬河|SFB|295" +
                            "@sgd|韶关东|SGQ|296" +
                            "@shg|山海关|SHD|297" +
                            "@shu|绥化|SHB|298" +
                            "@sjt|苏家屯|SXT|299" +
                            "@smi|三明|SMS|300" +
                            "@smx|三门峡|SMF|301" +
                            "@sna|商南|ONY|302" +
                            "@sni|遂宁|NIW|303" +
                            "@spi|四平|SPT|304" +
                            "@sqi|商丘|SQF|305" +
                            "@sra|上饶|SRG|306" +
                            "@sso|宿松|OAH|307" +
                            "@sto|汕头|OTQ|308" +
                            "@swu|邵武|SWS|309" +
                            "@sya|邵阳|SYQ|310" +
                            "@sya|十堰|SNN|311" +
                            "@sya|三亚|SEQ|312" +
                            "@sys|双鸭山|SSB|313" +
                            "@syu|松原|VYT|314" +
                            "@szh|朔州|SUV|315" +
                            "@szh|宿州|OXH|316" +
                            "@szh|随州|SZN|317" +
                            "@szh|苏州|SZH|318" +
                            "@szh|深圳|SZQ|319" +
                            "@szx|深圳西|OSQ|320" +
                            "@tgu|潼关|TGY|321" +
                            "@tgu|塘沽|TGP|322" +
                            "@the|塔河|TXX|323" +
                            "@thu|通化|THL|324" +
                            "@tla|泰来|TLX|325" +
                            "@tlf|吐鲁番|TFR|326" +
                            "@tli|通辽|TLD|327" +
                            "@tli|铁岭|TLT|328" +
                            "@tlz|陶赖昭|TPT|329" +
                            "@tme|图们|TML|330" +
                            "@tre|铜仁|RDQ|331" +
                            "@tsb|唐山北|FUP|332" +
                            "@tsh|天水|TSJ|333" +
                            "@tsh|泰山|TAK|334" +
                            "@tsh|唐山|TSP|335" +
                            "@typ|通远堡|TYT|336" +
                            "@tzh|泰州|UTH|337" +
                            "@tzi|桐梓|TZW|338" +
                            "@tzx|通州西|TAP|339" +
                            "@wch|武昌|WCN|340" +
                            "@wfd|瓦房店|WDT|341" +
                            "@whi|威海|WKK|342" +
                            "@whu|芜湖|WHH|343" +
                            "@whx|乌海西|WXC|344" +
                            "@wlo|武隆|WLW|345" +
                            "@wlt|乌兰浩特|WWT|346" +
                            "@wna|渭南|WNY|347" +
                            "@wsh|威舍|WSM|348" +
                            "@wts|歪头山|WIT|349" +
                            "@wwe|武威|WUJ|350" +
                            "@wwn|武威南|WWJ|351" +
                            "@wxi|乌西|WXR|352" +
                            "@wxi|无锡|WXH|353" +
                            "@wyl|乌伊岭|WPB|354" +
                            "@wys|武夷山|WAS|355" +
                            "@wyu|万源|WYY|356" +
                            "@wzh|梧州|WZZ|357" +
                            "@wzh|温州|RZH|358" +
                            "@wzh|万州|WYW|359" +
                            "@wzn|温州南|VRH|360" +
                            "@xch|西昌|ECW|361" +
                            "@xch|许昌|XCF|362" +
                            "@xcn|西昌南|ENW|363" +
                            "@xfa|香坊|XFB|364" +
                            "@xga|轩岗|XGV|365" +
                            "@xgu|兴国|EUG|366" +
                            "@xha|宣汉|XHY|367" +
                            "@xhu|新晃|XLQ|368" +
                            "@xhu|新会|EFQ|369" +
                            "@xlt|锡林浩特|XTC|370" +
                            "@xlx|兴隆县|EXP|371" +
                            "@xmb|厦门北|XKS|372" +
                            "@xme|厦门|XMS|373" +
                            "@xsh|秀山|ETW|374" +
                            "@xta|向塘|XTG|375" +
                            "@xwe|宣威|XWM|376" +
                            "@xxi|新乡|XXF|377" +
                            "@xya|咸阳|XYY|378" +
                            "@xya|信阳|XUN|379" +
                            "@xya|襄阳|XFN|380" +
                            "@xyc|熊岳城|XYT|381" +
                            "@xyi|兴义|XRZ|382" +
                            "@xyi|新沂|VIH|383" +
                            "@xyu|新余|XUG|384" +
                            "@xzh|徐州|XCH|385" +
                            "@yan|延安|YWY|386" +
                            "@ybi|宜宾|YBW|387" +
                            "@ybn|亚布力南|YWB|388" +
                            "@ybs|叶柏寿|YBD|389" +
                            "@ycd|宜昌东|HAN|390" +
                            "@ych|运城|YNV|391" +
                            "@ych|永川|YCW|392" +
                            "@ych|宜昌|YCN|393" +
                            "@ych|伊春|YCB|394" +
                            "@ych|盐城|AFH|395" +
                            "@ych|宜春|YCG|396" +
                            "@yci|榆次|YCV|397" +
                            "@ycu|杨村|YBP|398" +
                            "@yga|燕岗|YGW|399" +
                            "@yji|延吉|YJL|400" +
                            "@yji|永济|YIV|401" +
                            "@yko|营口|YKT|402" +
                            "@yks|牙克石|YKX|403" +
                            "@yli|玉林|YLZ|404" +
                            "@yli|榆林|ALY|405" +
                            "@ymp|一面坡|YPB|406" +
                            "@yni|伊宁|YMR|407" +
                            "@ypg|阳平关|YAY|408" +
                            "@ypi|原平|YPV|409" +
                            "@ypi|玉屏|YZW|410" +
                            "@yqu|玉泉|YQB|411" +
                            "@ysh|玉山|YNG|412" +
                            "@ysh|营山|NUW|413" +
                            "@yta|烟台|YAK|414" +
                            "@yta|鹰潭|YTG|415" +
                            "@yth|伊图里河|YEX|416" +
                            "@ytx|玉田县|ATP|417" +
                            "@ywu|义乌|YWH|418" +
                            "@yxi|义县|YXD|419" +
                            "@yxi|阳新|YON|420" +
                            "@yya|益阳|AEQ|421" +
                            "@yya|岳阳|YYQ|422" +
                            "@yzh|永州|AOQ|423" +
                            "@yzh|扬州|YLH|424" +
                            "@zbo|淄博|ZBK|425" +
                            "@zgo|自贡|ZGW|426" +
                            "@zhb|珠海北|ZIQ|427" +
                            "@zji|湛江|ZJZ|428" +
                            "@zji|镇江|ZJH|429" +
                            "@zjj|张家界|DIQ|430" +
                            "@zjn|张家口南|ZMP|431" +
                            "@zko|周口|ZKN|432" +
                            "@zlt|扎兰屯|ZTX|433" +
                            "@zmd|驻马店|ZDN|434" +
                            "@zqi|肇庆|ZVQ|435" +
                            "@zto|昭通|ZDW|436" +
                            "@zwe|中卫|ZWJ|437" +
                            "@zya|资阳|ZYW|438" +
                            "@zyi|遵义|ZIW|439" +
                            "@zzh|资中|ZZW|440" +
                            "@zzh|株洲|ZZQ|441" +
                            "@zzh|枣庄|ZEK|442" +
                            "@zzx|枣庄西|ZFK|443" +
                            "@aax|昂昂溪|AAX|444" +
                            "@ach|阿城|ACB|445" +
                            "@ada|安达|ADX|446" +
                            "@adu|安多|ADO|447" +
                            "@agu|安广|AGT|448" +
                            "@ahu|安化|PKQ|449" +
                            "@aji|阿金|AJD|450" +
                            "@aji|鳌江|ARH|451" +
                            "@aky|安口窑|AYY|452" +
                            "@alu|安陆|ALN|453" +
                            "@ame|阿木尔|JTX|454" +
                            "@aqx|安庆西|APH|455" +
                            "@atb|安亭北|ASH|456" +
                            "@ats|阿图什|ATR|457" +
                            "@atu|安图|ATL|458" +
                            "@axi|安溪|AXS|459" +
                            "@bao|博鳌|BWQ|460" +
                            "@bbn|蚌埠南|BMH|461" +
                            "@bch|巴楚|BCR|462" +
                            "@bdh|北戴河|BEP|463" +
                            "@bdi|保定|BDP|464" +
                            "@bdo|巴东|BNN|465" +
                            "@bgu|柏果|BGM|466" +
                            "@bhd|白河东|BIY|467" +
                            "@bho|贲红|BVC|468" +
                            "@bhs|宝华山|BWH|469" +
                            "@bhx|白河县|BEY|470" +
                            "@bji|北滘|IBQ|471" +
                            "@bji|碧江|BLQ|472" +
                            "@bjs|笔架山|BSB|473" +
                            "@bka|保康|BKD|474" +
                            "@bkp|白奎堡|BKB|475" +
                            "@bli|北流|BOZ|476" +
                            "@bli|宝林|BNB|477" +
                            "@bli|勃利|BLB|478" +
                            "@bls|宝龙山|BND|479" +
                            "@bmc|八面城|BMD|480" +
                            "@bmt|八面通|BMB|481" +
                            "@bpn|北票南|RPD|482" +
                            "@bql|宝泉岭|BQB|483" +
                            "@bsh|白沙|BSW|484" +
                            "@bss|白石山|BAL|485" +
                            "@bti|坂田|BTQ|486" +
                            "@bto|泊头|BZP|487" +
                            "@bxi|博兴|BXK|488" +
                            "@bxt|八仙筒|VXD|489" +
                            "@bys|白音胡硕|BCD|490" +
                            "@bzh|霸州|RMP|491" +
                            "@cbb|赤壁北|CIN|492" +
                            "@cch|长冲|CCM|493" +
                            "@cga|嵯岗|CAX|494" +
                            "@cge|长葛|CEF|495" +
                            "@cgp|柴沟堡|CGV|496" +
                            "@cgu|城固|CGY|497" +
                            "@cgz|成高子|CZB|498" +
                            "@cha|草海|WBW|499" +
                            "@che|册亨|CHZ|500" +
                            "@che|柴河|CHB|501" +
                            "@chk|草河口|CKT|502" +
                            "@chu|巢湖|CIH|503" +
                            "@cjg|蔡家沟|CJT|504" +
                            "@cjp|蔡家坡|CJY|505" +
                            "@cko|沧口|CKK|506" +
                            "@cle|昌乐|CLK|507" +
                            "@cli|慈利|CUQ|508" +
                            "@cli|昌黎|CLP|509" +
                            "@cmi|晨明|CMB|510" +
                            "@cpb|昌平北|VBP|511" +
                            "@csh|长寿|EFW|512" +
                            "@csh|苍石|CST|513" +
                            "@csh|楚山|CSB|514" +
                            "@csq|察素齐|CSC|515" +
                            "@cst|长山屯|CVT|516" +
                            "@cti|长汀|CES|517" +
                            "@cwa|春湾|CQQ|518" +
                            "@cxi|岑溪|CNZ|519" +
                            "@cxi|磁县|CIP|520" +
                            "@cxi|长兴|CFH|521" +
                            "@cxi|辰溪|CXQ|522" +
                            "@cya|磁窑|CYK|523" +
                            "@cya|朝阳|CYD|524" +
                            "@cya|城阳|CEK|525" +
                            "@cyc|朝阳川|CYL|526" +
                            "@cyz|朝阳镇|CZL|527" +
                            "@czb|滁州北|CUH|528" +
                            "@czb|常州北|ESH|529" +
                            "@czh|潮州|CKQ|530" +
                            "@czh|滁州|CXH|531" +
                            "@czx|郴州西|ICQ|532" +
                            "@czx|沧州西|CBP|533" +
                            "@dan|东安|DAZ|534" +
                            "@dan|德安|DAG|535" +
                            "@dba|到保|RBT|536" +
                            "@dbi|定边|DYJ|537" +
                            "@dbj|东边井|DBB|538" +
                            "@dch|德昌|DVW|539" +
                            "@dfa|东方|UFQ|540" +
                            "@dfe|东丰|DIL|541" +
                            "@dfe|丹凤|DGY|542" +
                            "@dgu|大关|RGW|543" +
                            "@dgu|东光|DGP|544" +
                            "@dgu|东莞|DAQ|545" +
                            "@dhq|大红旗|DQD|546" +
                            "@dhx|东海县|DQH|547" +
                            "@dji|东津|DKB|548" +
                            "@dla|东来|RVD|549" +
                            "@dlh|德令哈|DHO|550" +
                            "@dli|大林|DLD|551" +
                            "@dli|带岭|DLB|552" +
                            "@dlq|达拉特旗|DIC|553" +
                            "@dlx|达拉特西|DNC|554" +
                            "@dpf|大平房|DPD|555" +
                            "@dpu|大埔|DPI|556" +
                            "@dqi|德清|MOH|557" +
                            "@dqi|道清|DML|558" +
                            "@dqs|对青山|DQB|559" +
                            "@dsh|独山|RWW|560" +
                            "@dsh|砀山|DKH|561" +
                            "@dsh|东升|DRQ|562" +
                            "@dst|大石头|DSL|563" +
                            "@dta|定陶|DQK|564" +
                            "@dta|灯塔|DGT|565" +
                            "@dta|东台|DBH|566" +
                            "@dth|东通化|DTL|567" +
                            "@dtu|丹徒|RUH|568" +
                            "@dxi|东乡|DXG|569" +
                            "@dxi|代县|DKV|570" +
                            "@dxi|当雄|DAO|571" +
                            "@dxi|定西|DSJ|572" +
                            "@dxz|东辛庄|DXD|573" +
                            "@dya|打羊|RNW|574" +
                            "@dya|大雁|DYX|575" +
                            "@dya|当阳|DYN|576" +
                            "@dya|德阳|DYW|577" +
                            "@dya|丹阳|DYH|578" +
                            "@dyb|丹阳北|EXH|579" +
                            "@dyd|大英东|IAW|580" +
                            "@dyu|岱岳|RYV|581" +
                            "@dyu|定远|EWH|582" +
                            "@dyz|大营镇|DJP|583" +
                            "@dzd|德州东|DIP|584" +
                            "@dzh|低庄|DVQ|585" +
                            "@dzh|东镇|DNV|586" +
                            "@dzh|道州|DFZ|587" +
                            "@dzh|东至|DCH|588" +
                            "@dzh|定州|DXP|589" +
                            "@ebi|峨边|EBW|590" +
                            "@edw|二道湾|RDX|591" +
                            "@eme|峨眉|EMW|592" +
                            "@ezh|鄂州|ECN|593" +
                            "@fan|福安|FAS|594" +
                            "@fch|丰城|FCG|595" +
                            "@fcn|丰城南|FNG|596" +
                            "@fdo|峰洞|FDW|597" +
                            "@fdo|肥东|FIH|598" +
                            "@fha|福海|FHR|599" +
                            "@fhc|凤凰城|FHT|600" +
                            "@fhu|奉化|FHH|601" +
                            "@flt|福利屯|FTB|602" +
                            "@fna|阜南|FNH|603" +
                            "@fni|抚宁|FNP|604" +
                            "@fni|阜宁|AKH|605" +
                            "@fqi|福清|FQS|606" +
                            "@fqu|福泉|VMW|607" +
                            "@fsh|丰顺|FUQ|608" +
                            "@fsh|繁峙|FSV|609" +
                            "@fxd|富县东|FDY|610" +
                            "@fxi|凤县|FXY|611" +
                            "@fxi|费县|FXK|612" +
                            "@fya|凤阳|FUH|613" +
                            "@fya|汾阳|FAV|614" +
                            "@fyi|分宜|FYG|615" +
                            "@fyu|富裕|FYX|616" +
                            "@fyu|富源|FYM|617" +
                            "@fyu|扶余|FYT|618" +
                            "@fzh|凤州|FZY|619" +
                            "@fzh|丰镇|FZC|620" +
                            "@gan|固安|GFP|621" +
                            "@gan|广安|VJW|622" +
                            "@gbd|高碑店|GBP|623" +
                            "@gbz|沟帮子|GBD|624" +
                            "@gch|藁城|GEP|625" +
                            "@gch|谷城|GCN|626" +
                            "@gcz|古城镇|GZB|627" +
                            "@gde|广德|GRH|628" +
                            "@gdi|贵定|GTW|629" +
                            "@gdn|贵定南|IDW|630" +
                            "@gga|贵港|GGZ|631" +
                            "@ggm|葛根庙|GGT|632" +
                            "@ggu|甘谷|GGJ|633" +
                            "@ghe|甘河|GAX|634" +
                            "@gla|古浪|GLJ|635" +
                            "@gla|皋兰|GEJ|636" +
                            "@gli|关林|GLF|637" +
                            "@glu|甘洛|VOW|638" +
                            "@gmi|高密|GMK|639" +
                            "@gpi|高平|GPF|640" +
                            "@gqb|甘泉北|GEY|641" +
                            "@gqc|共青城|GAG|642" +
                            "@gqk|甘旗卡|GQD|643" +
                            "@gsh|赶水|GSW|644" +
                            "@gsz|高山子|GSD|645" +
                            "@gta|高台|GTJ|646" +
                            "@gti|古田|GTS|647" +
                            "@gti|官厅|GTP|648" +
                            "@gto|广通|GOM|649" +
                            "@gxi|贵溪|GXG|650" +
                            "@gya|涡阳|GYH|651" +
                            "@gyi|巩义|GXF|652" +
                            "@gyi|高邑|GIP|653" +
                            "@gyn|巩义南|GYF|654" +
                            "@gyu|菇园|GYL|655" +
                            "@gyu|固原|GUJ|656" +
                            "@gyz|公营子|GYD|657" +
                            "@gze|光泽|GZS|658" +
                            "@gzh|瓜州|GZJ|659" +
                            "@gzh|固镇|GEH|660" +
                            "@gzh|盖州|GXT|661" +
                            "@gzh|古镇|GNQ|662" +
                            "@gzs|冠豸山|GSS|663" +
                            "@han|红安|HWN|664" +
                            "@han|淮安南|AMH|665" +
                            "@hax|海安县|HIH|666" +
                            "@hax|红安西|VXN|667" +
                            "@hbe|海北|HEB|668" +
                            "@hbi|鹤壁|HAF|669" +
                            "@hch|华城|VCQ|670" +
                            "@hch|河唇|HCZ|671" +
                            "@hch|海城|HCT|672" +
                            "@hch|合川|WKW|673" +
                            "@hcu|黄村|HCP|674" +
                            "@hde|化德|HGC|675" +
                            "@hdo|洪洞|HDV|676" +
                            "@heg|哈尔盖|HRJ|677" +
                            "@hfe|横峰|HFG|678" +
                            "@hgz|红光镇|IGW|679" +
                            "@hji|和静|HJR|680" +
                            "@hji|获嘉|HJF|681" +
                            "@hji|涵江|HJS|682" +
                            "@hkn|河口南|HKJ|683" +
                            "@hko|黄口|KOH|684" +
                            "@hko|湖口|HKG|685" +
                            "@hla|呼兰|HUB|686" +
                            "@hlb|葫芦岛北|HPD|687" +
                            "@hlh|哈拉海|HIT|688" +
                            "@hlh|浩良河|HHB|689" +
                            "@hli|虎林|VLB|690" +
                            "@hli|海林|HRB|691" +
                            "@hli|鹤立|HOB|692" +
                            "@hli|桦林|HIB|693" +
                            "@hlo|和龙|HLL|694" +
                            "@hme|黄梅|VEH|695" +
                            "@hmt|蛤蟆塘|HMT|696" +
                            "@hnh|黄泥河|HHL|697" +
                            "@hni|海宁|HNH|698" +
                            "@hno|惠农|HMJ|699" +
                            "@hpi|和平|VAQ|700" +
                            "@hqi|花桥|VQH|701" +
                            "@hre|怀仁|HRV|702" +
                            "@hro|华容|HRN|703" +
                            "@hsb|华山北|HDY|704" +
                            "@hsd|黄松甸|HDL|705" +
                            "@hsg|和什托洛盖|VSR|706" +
                            "@hsh|汉寿|VSQ|707" +
                            "@hsh|红山|VSB|708" +
                            "@hsh|衡山|HSQ|709" +
                            "@hsh|黑水|HOT|710" +
                            "@hsh|惠山|VCH|711" +
                            "@hsw|海石湾|HSO|712" +
                            "@hsx|衡山西|HEQ|713" +
                            "@hta|桓台|VTK|714" +
                            "@hta|黑台|HQB|715" +
                            "@hto|会同|VTQ|716" +
                            "@hwa|海湾|RWH|717" +
                            "@hxi|红星|VXB|718" +
                            "@hxi|徽县|HYY|719" +
                            "@hya|红彦|VIX|720" +
                            "@hya|河阳|IOW|721" +
                            "@hya|海阳|HYK|722" +
                            "@hyd|衡阳东|HVQ|723" +
                            "@hyi|华蓥|HUW|724" +
                            "@hyi|汉阴|HQY|725" +
                            "@hyu|汉源|WHW|726" +
                            "@hyu|湟源|HNO|727" +
                            "@hyu|花园|HUN|728" +
                            "@hyu|河源|VIQ|729" +
                            "@hzh|霍州|HZV|730" +
                            "@hzh|黄州|VON|731" +
                            "@hzx|惠州西|VXQ|732" +
                            "@jbi|靖边|JIY|733" +
                            "@jbt|金宝屯|JBD|734" +
                            "@jch|鄄城|JCK|735" +
                            "@jch|金昌|JCJ|736" +
                            "@jde|峻德|JDB|737" +
                            "@jdo|鸡东|JOB|738" +
                            "@jdu|江都|UDH|739" +
                            "@jha|静海|JHP|740" +
                            "@jhe|精河|JHR|741" +
                            "@jhn|精河南|JIR|742" +
                            "@jhu|江华|JHZ|743" +
                            "@jhu|建湖|AJH|744" +
                            "@jjg|纪家沟|VJD|745" +
                            "@jji|江津|JJW|746" +
                            "@jji|姜家|JJB|747" +
                            "@jji|晋江|JJS|748" +
                            "@jke|金坑|JKT|749" +
                            "@jme|江门|JWQ|750" +
                            "@jna|莒南|JOK|751" +
                            "@jou|建瓯|JVS|752" +
                            "@jqi|江桥|JQX|753" +
                            "@jsa|九三|SSX|754" +
                            "@jsb|金山北|EGH|755" +
                            "@jsh|嘉善|JSH|756" +
                            "@jsh|京山|JCN|757" +
                            "@jsh|建始|JRN|758" +
                            "@jsn|嘉善南|EAH|759" +
                            "@jst|金山屯|JTB|760" +
                            "@jta|景泰|JTJ|761" +
                            "@jwe|吉文|JWX|762" +
                            "@jxi|介休|JXV|763" +
                            "@jxi|嘉祥|JUK|764" +
                            "@jxi|进贤|JUG|765" +
                            "@jxi|莒县|JKK|766" +
                            "@jxi|嘉兴|JXH|767" +
                            "@jxn|嘉兴南|EPH|768" +
                            "@jya|姜堰|UEH|769" +
                            "@jya|简阳|JYW|770" +
                            "@jya|建阳|JYS|771" +
                            "@jya|揭阳|JRQ|772" +
                            "@jye|巨野|JYK|773" +
                            "@jyo|江永|JYZ|774" +
                            "@jyu|江源|SZL|775" +
                            "@jyu|缙云|JYH|776" +
                            "@jyu|济源|JYF|777" +
                            "@jzb|胶州北|JZK|778" +
                            "@jzd|焦作东|WEF|779" +
                            "@jzh|晋州|JXP|780" +
                            "@jzh|胶州|JXK|781" +
                            "@jzh|靖州|JEQ|782" +
                            "@jzh|金寨|JZH|783" +
                            "@jzn|锦州南|JOD|784" +
                            "@jzu|焦作|JOF|785" +
                            "@jzw|旧庄窝|JVP|786" +
                            "@kan|开安|KAT|787" +
                            "@kch|库车|KCR|788" +
                            "@kde|库都尔|KDX|789" +
                            "@kjj|康金井|KJB|790" +
                            "@kly|克拉玛依|KHR|791" +
                            "@kqi|口前|KQL|792" +
                            "@ksh|奎山|KAB|793" +
                            "@ksh|昆山|KSH|794" +
                            "@kto|开通|KTT|795" +
                            "@kyh|克一河|KHX|796" +
                            "@kzh|康庄|KZP|797" +
                            "@lbi|老边|LLT|798" +
                            "@lbi|来宾|UBZ|799" +
                            "@lbx|灵宝西|LPF|800" +
                            "@lch|龙川|LUQ|801" +
                            "@lch|乐昌|LCQ|802" +
                            "@lch|聊城|UCK|803" +
                            "@lcu|蓝村|LCK|804" +
                            "@ldu|乐都|LDO|805" +
                            "@lfa|廊坊|LJP|806" +
                            "@lfb|廊坊北|LFP|807" +
                            "@lfe|禄丰|LFM|808" +
                            "@lha|拉哈|LHX|809" +
                            "@lha|凌海|JID|810" +
                            "@lha|临海|UFH|811" +
                            "@lhe|柳河|LNL|812" +
                            "@lhe|六合|KLH|813" +
                            "@lhz|六合镇|LEX|814" +
                            "@ljh|刘家河|LVT|815" +
                            "@lji|两家|UJT|816" +
                            "@lji|庐江|UJH|817" +
                            "@lji|廉江|LJZ|818" +
                            "@lji|龙江|LJX|819" +
                            "@lji|罗江|LJW|820" +
                            "@lji|连江|LKS|821" +
                            "@ljk|莲江口|LHB|822" +
                            "@lka|兰考|LKF|823" +
                            "@lko|林口|LKB|824" +
                            "@lkp|路口铺|LKQ|825" +
                            "@lla|老莱|LAX|826" +
                            "@lli|零陵|UWZ|827" +
                            "@lli|临澧|LWQ|828" +
                            "@lli|兰棱|LLB|829" +
                            "@lli|龙里|LLW|830" +
                            "@llo|卢龙|UAP|831" +
                            "@lmd|里木店|LMB|832" +
                            "@lna|龙南|UNG|833" +
                            "@lpi|梁平|UQW|834" +
                            "@lpi|罗平|LPM|835" +
                            "@lps|乐平市|LPG|836" +
                            "@lqi|临清|UQK|837" +
                            "@lsd|冷水江东|UDQ|838" +
                            "@lsg|连山关|LGT|839" +
                            "@lsh|乐山|UTW|840" +
                            "@lsh|丽水|USH|841" +
                            "@lsh|露水河|LUL|842" +
                            "@lsh|灵石|LSV|843" +
                            "@lsh|罗山|LRN|844" +
                            "@lsh|梁山|LMK|845" +
                            "@lsh|鲁山|LAF|846" +
                            "@lsh|庐山|LSG|847" +
                            "@lsh|陵水|LIQ|848" +
                            "@lsp|林盛堡|LBT|849" +
                            "@lsz|梨树镇|LSB|850" +
                            "@lta|芦台|LTP|851" +
                            "@lta|轮台|LAR|852" +
                            "@lta|黎塘|LTZ|853" +
                            "@lwu|灵武|LNJ|854" +
                            "@lxi|陇县|LXY|855" +
                            "@lxi|临湘|LXQ|856" +
                            "@lxi|莱西|LXK|857" +
                            "@lxi|朗乡|LXB|858" +
                            "@lxi|芦溪|LUG|859" +
                            "@lxi|滦县|UXP|860" +
                            "@lya|莱阳|LYK|861" +
                            "@lya|略阳|LYY|862" +
                            "@lya|辽阳|LYT|863" +
                            "@lyb|临沂北|UYK|864" +
                            "@lyg|连云港|UIH|865" +
                            "@lyi|老营|LXL|866" +
                            "@lyi|临颍|LNF|867" +
                            "@lyo|龙游|LMH|868" +
                            "@lyu|涞源|LYP|869" +
                            "@lyu|涟源|LAQ|870" +
                            "@lyu|罗源|LVS|871" +
                            "@lyx|耒阳西|LPQ|872" +
                            "@lze|临泽|LEJ|873" +
                            "@lzh|雷州|UAQ|874" +
                            "@lzh|来舟|LZS|875" +
                            "@lzh|龙镇|LZA|876" +
                            "@lzh|鹿寨|LIZ|877" +
                            "@lzh|六枝|LIW|878" +
                            "@mas|马鞍山|MAH|879" +
                            "@mcb|麻城北|MBN|880" +
                            "@mch|明城|MCL|881" +
                            "@mch|渑池|MCF|882" +
                            "@mcn|渑池南|MNF|883" +
                            "@mdu|弥渡|MDF|884" +
                            "@mes|帽儿山|MRB|885" +
                            "@mga|明港|MGN|886" +
                            "@mhk|梅河口|MHL|887" +
                            "@mjg|孟家岗|MGB|888" +
                            "@mla|美兰|MHQ|889" +
                            "@mld|汨罗东|MQQ|890" +
                            "@mli|穆棱|MLB|891" +
                            "@mli|马林|MID|892" +
                            "@mlo|汨罗|MLQ|893" +
                            "@mlt|木里图|MUD|894" +
                            "@mni|冕宁|UGW|895" +
                            "@mpa|沐滂|MPQ|896" +
                            "@mqh|马桥河|MQB|897" +
                            "@mqi|闽清|MQS|898" +
                            "@mqu|民权|MQF|899" +
                            "@msh|眉山|MSW|900" +
                            "@msh|麻山|MAB|901" +
                            "@mtz|庙台子|MZB|902" +
                            "@mxi|孟溪|MZQ|903" +
                            "@mxi|勉县|MVY|904" +
                            "@mxi|美溪|MEB|905" +
                            "@mya|麻阳|MVQ|906" +
                            "@myi|米易|MMW|907" +
                            "@myu|麦园|MYS|908" +
                            "@mzh|米脂|MEY|909" +
                            "@nan|农安|NAT|910" +
                            "@nan|南安|NAS|911" +
                            "@nde|宁德|NES|912" +
                            "@ngd|南宫东|NFP|913" +
                            "@ngu|宁国|NNH|914" +
                            "@nha|宁海|NHH|915" +
                            "@nhu|南华|NHS|916" +
                            "@nji|宁家|NVT|917" +
                            "@nji|能家|NJD|918" +
                            "@nko|南口|NKP|919" +
                            "@nkq|南口前|NKT|920" +
                            "@nla|南朗|NNQ|921" +
                            "@nli|乃林|NLD|922" +
                            "@nlk|尼勒克|NIR|923" +
                            "@nlx|宁陵县|NLF|924" +
                            "@nma|奈曼|NMD|925" +
                            "@npn|南平南|NNS|926" +
                            "@nqu|那曲|NQO|927" +
                            "@nta|南台|NTT|928" +
                            "@nwu|宁武|NWV|929" +
                            "@nxb|南翔北|NEH|930" +
                            "@nxi|宁乡|NXQ|931" +
                            "@nxi|内乡|NXF|932" +
                            "@nzh|南召|NAF|933" +
                            "@nzm|南杂木|NZT|934" +
                            "@pan|蓬安|PAW|935" +
                            "@pay|平安驿|PNO|936" +
                            "@pcd|蒲城东|PEY|937" +
                            "@pde|裴德|PDB|938" +
                            "@pdx|平顶山西|BFF|939" +
                            "@pgu|平果|PGZ|940" +
                            "@pjb|盘锦北|PBD|941" +
                            "@pld|普兰店|PLT|942" +
                            "@psh|彭山|PSW|943" +
                            "@psh|磐石|PSL|944" +
                            "@psh|平山|PSB|945" +
                            "@psh|彭水|PHW|946" +
                            "@pta|平台|PVT|947" +
                            "@pti|莆田|PTS|948" +
                            "@pxi|普雄|POW|949" +
                            "@pxi|蓬溪|KZW|950" +
                            "@pya|平遥|PYV|951" +
                            "@pyi|平邑|PIK|952" +
                            "@pyu|平原|PYK|953" +
                            "@pze|彭泽|PZG|954" +
                            "@pzh|平庄|PZD|955" +
                            "@pzh|邳州|PJH|956" +
                            "@pzi|泡子|POD|957" +
                            "@qan|迁安|QQP|958" +
                            "@qan|庆安|QAB|959" +
                            "@qdo|祁东|QRQ|960" +
                            "@qfd|曲阜东|QAK|961" +
                            "@qfu|曲阜|QFK|962" +
                            "@qha|琼海|QYQ|963" +
                            "@qhm|清河门|QHD|964" +
                            "@qji|綦江|QJW|965" +
                            "@qji|全椒|INH|966" +
                            "@qjp|祁家堡|QBT|967" +
                            "@qjx|清涧县|QNY|968" +
                            "@qls|青龙山|QGH|969" +
                            "@qme|祁门|QIH|970" +
                            "@qsh|确山|QSN|971" +
                            "@qsh|青山|QSB|972" +
                            "@qsh|清水|QUJ|973" +
                            "@qsy|戚墅堰|QYH|974" +
                            "@qti|青田|QVH|975" +
                            "@qtx|青铜峡|QTJ|976" +
                            "@qxi|祁县|QXV|977" +
                            "@qxi|青县|QXP|978" +
                            "@qxi|淇县|QXF|979" +
                            "@qxi|渠县|QRW|980" +
                            "@qya|泉阳|QYL|981" +
                            "@qya|祁阳|QVQ|982" +
                            "@qyu|清原|QYT|983" +
                            "@qyu|清远|QBQ|984" +
                            "@qzd|钦州东|QDZ|985" +
                            "@qzh|全州|QZZ|986" +
                            "@qzs|青州市|QZK|987" +
                            "@ran|瑞安|RAH|988" +
                            "@rch|荣昌|RCW|989" +
                            "@rch|瑞昌|RCG|990" +
                            "@rga|如皋|RBH|991" +
                            "@rgu|容桂|RUQ|992" +
                            "@rqi|任丘|RQP|993" +
                            "@rsh|乳山|ROK|994" +
                            "@rsh|融水|RSZ|995" +
                            "@rxi|容县|RXZ|996" +
                            "@rya|汝阳|RYF|997" +
                            "@rya|饶阳|RVP|998" +
                            "@ryh|绕阳河|RHD|999" +
                            "@rzh|汝州|ROF|1000" +
                            "@sbi|施秉|AQW|1001" +
                            "@sch|商城|SWN|1002" +
                            "@sch|顺昌|SCS|1003" +
                            "@sch|沙城|SCP|1004" +
                            "@sch|舒城|OCH|1005" +
                            "@scz|山城镇|SCL|1006" +
                            "@sda|山丹|SDJ|1007" +
                            "@sde|绥德|ODY|1008" +
                            "@sde|顺德|ORQ|1009" +
                            "@sdo|邵东|SOQ|1010" +
                            "@sdo|水洞|SIL|1011" +
                            "@sdu|商都|SXC|1012" +
                            "@sfa|绅坊|OLH|1013" +
                            "@sft|四方台|STB|1014" +
                            "@sfu|水富|OTW|1015" +
                            "@sgl|桑根达来|OGC|1016" +
                            "@sgu|韶关|SNQ|1017" +
                            "@sha|上杭|JBS|1018" +
                            "@shs|沙河市|VOP|1019" +
                            "@shx|三河县|OXP|1020" +
                            "@shy|四合永|OHD|1021" +
                            "@shz|石河子|SZR|1022" +
                            "@sjd|三家店|ODP|1023" +
                            "@sjh|松江河|SJL|1024" +
                            "@sji|沈家|OJB|1025" +
                            "@sji|松江|SAH|1026" +
                            "@sjk|三江口|SKD|1027" +
                            "@sjn|松江南|IMH|1028" +
                            "@sjx|三江县|SOZ|1029" +
                            "@sjz|松江镇|OZL|1030" +
                            "@slh|疏勒河|SHJ|1031" +
                            "@sli|石岭|SOL|1032" +
                            "@sli|石林|SLM|1033" +
                            "@sli|绥棱|SIB|1034" +
                            "@slo|石龙|SLQ|1035" +
                            "@slq|萨拉齐|SLC|1036" +
                            "@slu|商洛|OLY|1037" +
                            "@smn|三门峡南|SCF|1038" +
                            "@smx|三门峡西|SXF|1039" +
                            "@smx|石门县|OMQ|1040" +
                            "@smx|三门县|OQH|1041" +
                            "@sni|肃宁|SYP|1042" +
                            "@son|宋|SOB|1043" +
                            "@spa|双牌|SBZ|1044" +
                            "@spi|遂平|SON|1045" +
                            "@sqn|商丘南|SPF|1046" +
                            "@sqx|石泉县|SXY|1047" +
                            "@sqz|石桥子|SQT|1048" +
                            "@src|石人城|SRB|1049" +
                            "@ssh|神树|SWB|1050" +
                            "@ssh|山市|SQB|1051" +
                            "@ssh|三水|SJQ|1052" +
                            "@ssh|松树|SFT|1053" +
                            "@ssh|泗水|OSK|1054" +
                            "@ssh|鄯善|SSR|1055" +
                            "@ssp|三十里堡|SST|1056" +
                            "@ssz|松树镇|SSL|1057" +
                            "@swx|沙湾县|SXR|1058" +
                            "@sxi|遂溪|SXZ|1059" +
                            "@sxi|沙县|SAS|1060" +
                            "@sxi|歙县|OVH|1061" +
                            "@sxi|绍兴|SOH|1062" +
                            "@sya|绥阳|SYB|1063" +
                            "@sya|沭阳|FMH|1064" +
                            "@syp|三源浦|SYL|1065" +
                            "@syu|上园|SUD|1066" +
                            "@syu|上虞|BDH|1067" +
                            "@szb|绥中北|SND|1068" +
                            "@szb|苏州北|OHH|1069" +
                            "@szd|宿州东|SRH|1070" +
                            "@szh|尚志|SZB|1071" +
                            "@szh|深州|OZP|1072" +
                            "@szh|绥中|SZD|1073" +
                            "@szi|松滋|SIN|1074" +
                            "@szo|师宗|SEM|1075" +
                            "@szq|苏州新区|ITH|1076" +
                            "@szq|苏州园区|KAH|1077" +
                            "@szs|石嘴山|SZJ|1078" +
                            "@tan|台安|TID|1079" +
                            "@tan|泰安|TMK|1080" +
                            "@tba|桐柏|TBF|1081" +
                            "@tbe|通北|TBB|1082" +
                            "@tch|郯城|TZK|1083" +
                            "@tch|桐城|TTH|1084" +
                            "@tch|汤池|TCX|1085" +
                            "@tcu|桃村|TCK|1086" +
                            "@tda|通道|TRQ|1087" +
                            "@tdo|田东|TDZ|1088" +
                            "@tga|天岗|TGL|1089" +
                            "@tgu|太谷|TGV|1090" +
                            "@the|泰和|THG|1091" +
                            "@the|唐河|THF|1092" +
                            "@thu|太湖|TKH|1093" +
                            "@tji|团结|TIX|1094" +
                            "@tka|泰康|TKX|1095" +
                            "@tlh|图里河|TEX|1096" +
                            "@tli|铁力|TLB|1097" +
                            "@tli|铜陵|TJH|1098" +
                            "@tme|天门|TMN|1099" +
                            "@tms|太姥山|TLS|1100" +
                            "@tna|洮南|TVT|1101" +
                            "@tna|潼南|TVW|1102" +
                            "@tpc|太平川|TIT|1103" +
                            "@tpz|太平镇|TEB|1104" +
                            "@tqi|台前|TTK|1105" +
                            "@tqi|图强|TQX|1106" +
                            "@tsc|汤山城|TCT|1107" +
                            "@tsh|桃山|TAB|1108" +
                            "@twh|汤旺河|THB|1109" +
                            "@txi|同心|TXJ|1110" +
                            "@txi|土溪|TSW|1111" +
                            "@txi|桐乡|TCH|1112" +
                            "@tya|田阳|TRZ|1113" +
                            "@tyi|汤阴|TYF|1114" +
                            "@tyi|天义|TND|1115" +
                            "@tyl|驼腰岭|TIL|1116" +
                            "@tyu|汤原|TYB|1117" +
                            "@tzd|滕州东|TEK|1118" +
                            "@tzh|天镇|TZV|1119" +
                            "@tzh|天祝|TZJ|1120" +
                            "@tzh|滕州|TXK|1121" +
                            "@tzh|台州|TZH|1122" +
                            "@tzl|桐子林|TEW|1123" +
                            "@tzs|天柱山|QWH|1124" +
                            "@wan|文安|WBP|1125" +
                            "@wch|文昌|WEQ|1126" +
                            "@wdc|五大连池|WRB|1127" +
                            "@wde|文登|WBK|1128" +
                            "@wdg|五道沟|WDL|1129" +
                            "@wdi|文地|WNZ|1130" +
                            "@wdo|卫东|WVT|1131" +
                            "@wds|武当山|WRN|1132" +
                            "@wdu|望都|WDP|1133" +
                            "@weh|乌尔旗汗|WHX|1134" +
                            "@wfa|潍坊|WFK|1135" +
                            "@wfu|王府|WUT|1136" +
                            "@wgo|湾沟|WGL|1137" +
                            "@wha|乌海|WVC|1138" +
                            "@whe|苇河|WHB|1139" +
                            "@whu|卫辉|WHF|1140" +
                            "@wke|倭肯|WQB|1141" +
                            "@wlb|五龙背|WBT|1142" +
                            "@wlg|瓦拉干|WVX|1143" +
                            "@wli|五莲|WLK|1144" +
                            "@wli|温岭|VHH|1145" +
                            "@wlt|卧里屯|WLX|1146" +
                            "@wnb|渭南北|WBY|1147" +
                            "@wni|万年|WWG|1148" +
                            "@wni|万宁|WNQ|1149" +
                            "@wpu|吴堡|WUY|1150" +
                            "@wqi|吴桥|WUP|1151" +
                            "@wqi|武清|WWP|1152" +
                            "@wsh|武山|WSJ|1153" +
                            "@wsh|文水|WEV|1154" +
                            "@wts|五台山|WSV|1155" +
                            "@wwu|五五|WVR|1156" +
                            "@wxd|无锡东|WGH|1157" +
                            "@wxi|闻喜|WXV|1158" +
                            "@wxi|武乡|WVV|1159" +
                            "@wxi|卫星|WVB|1160" +
                            "@wxq|无锡新区|IFH|1161" +
                            "@wxu|武穴|WXN|1162" +
                            "@wyi|五营|WWB|1163" +
                            "@wyi|武义|RYH|1164" +
                            "@wzg|苇子沟|WZL|1165" +
                            "@wzt|王兆屯|WZB|1166" +
                            "@xan|兴安|XAZ|1167" +
                            "@xax|新安县|XAF|1168" +
                            "@xch|宣城|ECH|1169" +
                            "@xch|兴城|XCD|1170" +
                            "@xcz|下城子|XCB|1171" +
                            "@xde|喜德|EDW|1172" +
                            "@xdo|小东|XOD|1173" +
                            "@xfe|息烽|XFW|1174" +
                            "@xfe|襄汾|XFV|1175" +
                            "@xfe|信丰|EFG|1176" +
                            "@xga|新干|EGG|1177" +
                            "@xga|孝感|XGN|1178" +
                            "@xhe|襄河|XXB|1179" +
                            "@xhe|新和|XIR|1180" +
                            "@xhu|宣化|XHP|1181" +
                            "@xhu|新华|XHB|1182" +
                            "@xhu|新化|EHQ|1183" +
                            "@xhx|兴和西|XEC|1184" +
                            "@xhy|下花园|XYP|1185" +
                            "@xhz|小河镇|EKY|1186" +
                            "@xji|辛集|ENP|1187" +
                            "@xjt|许家屯|XJT|1188" +
                            "@xla|香兰|XNB|1189" +
                            "@xla|星朗|ELW|1190" +
                            "@xla|小榄|EAQ|1191" +
                            "@xld|兴隆店|XDD|1192" +
                            "@xle|新乐|ELP|1193" +
                            "@xli|西林|XYB|1194" +
                            "@xli|新林|XPX|1195" +
                            "@xli|小岭|XLB|1196" +
                            "@xli|西柳|GCT|1197" +
                            "@xli|仙林|XPH|1198" +
                            "@xlt|新立屯|XLD|1199" +
                            "@xlz|兴隆镇|XZB|1200" +
                            "@xmi|新民|XMD|1201" +
                            "@xms|西麻山|XMB|1202" +
                            "@xmt|下马塘|XAT|1203" +
                            "@xnb|咸宁北|XRN|1204" +
                            "@xni|咸宁|XNN|1205" +
                            "@xni|兴宁|ENQ|1206" +
                            "@xpi|西平|XPN|1207" +
                            "@xpu|溆浦|EPQ|1208" +
                            "@xpu|霞浦|XOS|1209" +
                            "@xpu|犀浦|XIW|1210" +
                            "@xqi|新邱|XQD|1211" +
                            "@xqi|新青|XQB|1212" +
                            "@xrq|仙人桥|XRL|1213" +
                            "@xsh|浠水|XZN|1214" +
                            "@xsh|徐水|XSP|1215" +
                            "@xsh|杏树|XSB|1216" +
                            "@xta|邢台|XTP|1217" +
                            "@xts|锡铁山|XRO|1218" +
                            "@xwe|徐闻|XJQ|1219" +
                            "@xxi|新县|XSN|1220" +
                            "@xxi|西乡|XQY|1221" +
                            "@xxi|西峡|XIF|1222" +
                            "@xxi|息县|ENN|1223" +
                            "@xxx|新兴县|XGQ|1224" +
                            "@xya|旬阳|XUY|1225" +
                            "@xya|向阳|XDB|1226" +
                            "@xyb|旬阳北|XBY|1227" +
                            "@xye|兴业|SNZ|1228" +
                            "@xyi|信宜|EEQ|1229" +
                            "@xyq|小扬气|XYX|1230" +
                            "@xyu|祥云|EXM|1231" +
                            "@xyx|夏邑县|EJH|1232" +
                            "@xzd|徐州东|UUH|1233" +
                            "@xzf|新帐房|XZX|1234" +
                            "@xzh|忻州|XXV|1235" +
                            "@xzh|学庄|EZW|1236" +
                            "@yan|永安|YAS|1237" +
                            "@yan|姚安|YAC|1238" +
                            "@yax|永安乡|YNB|1239" +
                            "@ybl|亚布力|YBB|1240" +
                            "@ybs|元宝山|YUD|1241" +
                            "@ych|迎春|YYB|1242" +
                            "@ych|郓城|YPK|1243" +
                            "@ych|宜城|YIN|1244" +
                            "@ych|晏城|YEK|1245" +
                            "@ych|禹城|YCK|1246" +
                            "@ych|应城|YHN|1247" +
                            "@ych|盐池|YKJ|1248" +
                            "@ych|阳春|YQQ|1249" +
                            "@ych|阳澄湖|AIH|1250" +
                            "@ycx|虞城县|IXH|1251" +
                            "@yde|永登|YDJ|1252" +
                            "@yde|英德|YDQ|1253" +
                            "@ydi|永定|YGS|1254" +
                            "@yds|雁荡山|YGH|1255" +
                            "@ydu|于都|YDG|1256" +
                            "@yfu|永福|YFZ|1257" +
                            "@yga|杨岗|YRB|1258" +
                            "@yga|阳高|YOV|1259" +
                            "@ygu|阳谷|YIK|1260" +
                            "@yha|友好|YOB|1261" +
                            "@yha|余杭|EVH|1262" +
                            "@yji|余江|YHG|1263" +
                            "@yji|叶集|YCH|1264" +
                            "@yji|盐津|AEW|1265" +
                            "@yji|燕郊|AJP|1266" +
                            "@yji|永嘉|URH|1267" +
                            "@yka|永康|RFH|1268" +
                            "@yla|永郎|YLW|1269" +
                            "@yli|伊林|YLB|1270" +
                            "@yli|彝良|ALW|1271" +
                            "@ylq|杨柳青|YQP|1272" +
                            "@ylw|亚龙湾|TWQ|1273" +
                            "@ylz|杨陵镇|YSY|1274" +
                            "@yma|义马|YMF|1275" +
                            "@yme|云梦|YMN|1276" +
                            "@ymo|元谋|YMM|1277" +
                            "@yms|一面山|YST|1278" +
                            "@ymz|玉门镇|YXJ|1279" +
                            "@yna|沂南|YNK|1280" +
                            "@yqb|阳泉北|YPP|1281" +
                            "@yqi|焉耆|YSR|1282" +
                            "@yqi|乐清|UPH|1283" +
                            "@ysh|颍上|YVH|1284" +
                            "@ysh|沂水|YUK|1285" +
                            "@ysh|榆社|YSV|1286" +
                            "@ysh|元氏|YSP|1287" +
                            "@ysh|偃师|YSF|1288" +
                            "@ysh|月山|YBF|1289" +
                            "@yta|源潭|YTQ|1290" +
                            "@ytp|牙屯堡|YTZ|1291" +
                            "@yts|烟筒山|YSL|1292" +
                            "@ytt|烟筒屯|YUX|1293" +
                            "@yxi|越西|YHW|1294" +
                            "@yxi|永修|ACG|1295" +
                            "@yya|酉阳|AFW|1296" +
                            "@yya|余姚|YYH|1297" +
                            "@yyd|弋阳东|YIG|1298" +
                            "@yyd|岳阳东|YIQ|1299" +
                            "@yyu|鸭园|YYL|1300" +
                            "@yzh|宜州|YSZ|1301" +
                            "@yzh|仪征|UZH|1302" +
                            "@yzh|兖州|YZK|1303" +
                            "@zan|镇安|ZEY|1304" +
                            "@zch|诸城|ZQK|1305" +
                            "@zch|子长|ZHY|1306" +
                            "@zch|枝城|ZCN|1307" +
                            "@zch|邹城|ZIK|1308" +
                            "@zda|章党|ZHT|1309" +
                            "@zdo|肇东|ZDB|1310" +
                            "@zgt|章古台|ZGD|1311" +
                            "@zgu|赵光|ZGB|1312" +
                            "@zhe|中和|ZHX|1313" +
                            "@zhm|中华门|VNH|1314" +
                            "@zjg|朱家沟|ZUB|1315" +
                            "@zji|诸暨|ZDH|1316" +
                            "@zjn|镇江南|ZEH|1317" +
                            "@zjt|周家屯|ZOD|1318" +
                            "@zjt|郑家屯|ZJD|1319" +
                            "@zjx|湛江西|ZWQ|1320" +
                            "@zla|镇赉|ZLT|1321" +
                            "@zlt|扎鲁特|ZLD|1322" +
                            "@zlx|扎赉诺尔西|ZXX|1323" +
                            "@zmt|樟木头|ZOQ|1324" +
                            "@zmu|中牟|ZGF|1325" +
                            "@zni|中宁|VNJ|1326" +
                            "@zpi|漳平|ZPS|1327" +
                            "@zpi|镇平|ZPF|1328" +
                            "@zqi|枣强|ZVP|1329" +
                            "@zqi|张桥|ZQY|1330" +
                            "@zqi|章丘|ZTK|1331" +
                            "@zrh|朱日和|ZRC|1332" +
                            "@zsb|中山北|ZGQ|1333" +
                            "@zsd|樟树东|ZOG|1334" +
                            "@zsh|钟山|ZSZ|1335" +
                            "@zsh|柞水|ZSY|1336" +
                            "@zsh|樟树|ZSG|1337" +
                            "@zsh|中山|ZSQ|1338" +
                            "@zsz|朱石寨|ZVW|1339" +
                            "@zwo|珠窝|ZOP|1340" +
                            "@zwu|彰武|ZWD|1341" +
                            "@zxi|资溪|ZXS|1342" +
                            "@zxi|镇西|ZVT|1343" +
                            "@zxi|钟祥|ZTN|1344" +
                            "@zxq|正镶白旗|ZXC|1345" +
                            "@zya|枣阳|ZYN|1346" +
                            "@zya|紫阳|ZVY|1347" +
                            "@zyb|竹园坝|ZAW|1348" +
                            "@zye|张掖|ZYJ|1349" +
                            "@zyu|镇远|ZUW|1350" +
                            "@zyx|朱杨溪|ZXW|1351" +
                            "@zzd|漳州东|GOS|1352" +
                            "@zzh|子洲|ZZY|1353" +
                            "@zzh|涿州|ZXP|1354" +
                            "@zzs|卓资山|ZZC|1355" +
                            "@zzx|株洲西|ZAQ|1356" +
                            "@szb|深圳北|SIQ|1357";
        #endregion
        private static List<Station> departureStations;
        private static List<Station> destinationStations;
        private static List<string> departureTimes;
        private static List<KeyValuePair<string, string>> ticketTypies;
        private static BindingList<TicketInfo> ticketInfoList;
        private static List<SeatType> selectedSeatType;
        private static List<KeyValuePair<string, string>> trainNumbers;
        private static OrderInfo orders;
        private static List<Passenger> passengers;
        private static BindingList<Passenger> ordersPassengers;
        private static string submutOrderRequestUrl;
        /// <summary>
        /// 防止点击复选框,代码勾选其他复选框时,造成的多次调用.
        /// </summary>

        public frmTicketQuery()
        {
            selectedSeatType = new List<SeatType>();
            trainNumbers=new List<KeyValuePair<string,string>>();
            ordersPassengers = new BindingList<Passenger>();
            submutOrderRequestUrl = "https://dynamic.12306.cn/otsweb/order/querySingleAction.do?method=submutOrderRequest";
            resetTrainNumers();
            InitializeComponent();
            initTicketType();
            initDepartureStation();
            initDestinationStation();
            initDepartureTimes();
            initFlpPassenger();
            initTicketDataGrid();
            initSeatTypies();
            initTrainPassType();
            initDgvOrder();
            tssVersion.Text = "版本: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            changeMoreOption();
        }

        #region 初始化控件
        private void initTicketType()
        {
            foreach (var item in TrainTypies)
            {
                CheckBox chkbox = new CheckBox();
                chkbox.Name = "chk" + item.Key;
                chkbox.Tag = item.Key;
                chkbox.Text = item.Value;
                chkbox.AutoSize = true;
                chkbox.CheckedChanged += new EventHandler(chkTrainTypies_CheckedChanged);
                flpTrainType.Controls.Add(chkbox);
            }
            (flpTrainType.Controls["chkQB"] as CheckBox).Checked = true;
        }

        private void initDepartureStation()
        {
            cboDepartureStation.DataSource = DepartureStations ;
            cboDepartureStation.ValueMember = "Code";
            cboDepartureStation.DisplayMember = "Name";
            cboDepartureStation.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboDepartureStation.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void initDestinationStation()
        {
            cboDestinationStation.DataSource =DestinationStations ;
            cboDestinationStation.ValueMember = "Code";
            cboDestinationStation.DisplayMember = "Name";
            cboDestinationStation.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboDestinationStation.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void initDepartureTimes()
        {
            cboDepartureTime.DataSource = DepartureTimes;
            cboDepartureTime.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboDepartureTime.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        void chkTrainTypies_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox currentCheckBox = sender as CheckBox;
            CheckBox selectAllCheckBox = flpTrainType.Controls["chkQB"] as CheckBox;
            Control.ControlCollection checkboxCollection = flpTrainType.Controls;
            CommUitl.SelectAllChkChange(currentCheckBox, selectAllCheckBox, checkboxCollection);
        }

        private void initTicketDataGrid()
        {
            dgvTiketInfo.RowPrePaint += new DataGridViewRowPrePaintEventHandler(dgvTiketInfo_RowPrePaint);
            dgvTiketInfo.AutoGenerateColumns = false;
            dgvTiketInfo.AllowUserToAddRows = false;
            dgvTiketInfo.RowHeadersVisible = false;

            DataGridViewCheckBoxColumn dgvcbcSlected = new DataGridViewCheckBoxColumn();
            dgvcbcSlected.Name = "dgvcbcSlected";
            dgvcbcSlected.HeaderText = "监控";
            dgvcbcSlected.DataPropertyName = "Selected";
            dgvcbcSlected.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            DataGridViewTextBoxColumn dgtbcTrainNo = new DataGridViewTextBoxColumn();
            dgtbcTrainNo.Name = "dgtbcTrainNo";
            dgtbcTrainNo.HeaderText = "车次";
            dgtbcTrainNo.DataPropertyName = "StationTrainCode";
            dgtbcTrainNo.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            DataGridViewTextBoxColumn dgtbcDepartureStation = new DataGridViewTextBoxColumn();
            dgtbcDepartureStation.Name = "dgtbcDepartureStation";
            dgtbcDepartureStation.HeaderText = "发站";
            dgtbcDepartureStation.DataPropertyName = "DepartureStation";
            dgtbcDepartureStation.Width = 88;

            DataGridViewTextBoxColumn dgtbcDrivingTime = new DataGridViewTextBoxColumn();
            dgtbcDrivingTime.Name = "dgtbcDrivingTime";
            dgtbcDrivingTime.HeaderText = "开车时间";
            dgtbcDrivingTime.DataPropertyName = "DrivingTime";
            dgtbcDrivingTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            DataGridViewTextBoxColumn dgtbcDestinationStation = new DataGridViewTextBoxColumn();
            dgtbcDestinationStation.Name = "dgtbcDestinationStation";
            dgtbcDestinationStation.HeaderText = "到站";
            dgtbcDestinationStation.DataPropertyName = "DestinationStation";
            dgtbcDestinationStation.Width = 88;

            DataGridViewTextBoxColumn dgtbcArrivalTime = new DataGridViewTextBoxColumn();
            dgtbcArrivalTime.Name = "dgtbcArrivalTime";
            dgtbcArrivalTime.HeaderText = "到达时间";
            dgtbcArrivalTime.DataPropertyName = "ArrivalTime";
            dgtbcArrivalTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            DataGridViewTextBoxColumn dgtbcElapsedTime = new DataGridViewTextBoxColumn();
            dgtbcElapsedTime.Name = "dgtbcElapsedTime";
            dgtbcElapsedTime.HeaderText = "历时";
            dgtbcElapsedTime.DataPropertyName = "ElapsedTime";
            dgtbcElapsedTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            dgvTiketInfo.Columns.AddRange(dgvcbcSlected,dgtbcTrainNo,dgtbcDepartureStation,dgtbcDrivingTime,dgtbcDestinationStation,dgtbcArrivalTime,dgtbcElapsedTime);

            SeatType seatType;
            for (int i = 0; i < CommData.SeatTypeCount; i++)
            {
                seatType = (SeatType)i;
                DataGridViewTextBoxColumn dgtbcSeetInfo = new DataGridViewTextBoxColumn();
                dgvTiketInfo.Name = "dgtbcSeetInfo" + seatType;
                dgtbcSeetInfo.HeaderText = SeatTypeDescriptionHelper.Description[seatType];
                dgtbcSeetInfo.DataPropertyName = seatType.ToString();
                dgtbcSeetInfo.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                dgvTiketInfo.Columns.Add(dgtbcSeetInfo);
            }

            setDgvReadOnly();
        }

        void setDgvReadOnly()
        {
            for (int i = 0; i < dgvTiketInfo.Columns.Count; i++)
            {
                if (i > 0)
                {
                    dgvTiketInfo.Columns[i].ReadOnly = true;
                }
            }
        }

        void dgvTiketInfo_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < dgvTiketInfo.Rows.Count)
            {
                TicketInfo ticketInfo = (dgvTiketInfo.Rows[e.RowIndex].DataBoundItem as TicketInfo);
                if (ticketInfo != null && ticketInfo.IsAvailable_Seat(selectedSeatType.ToArray()) == true)
                {
                    dgvTiketInfo.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LawnGreen;
                }
                else
                {
                    dgvTiketInfo.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void initSeatTypies()
        {
            SeatType seatType;
            CheckBox checkbox;
            for (int i = 0; i < CommUitl.GetEnumCount(typeof(SeatType)); i++)
            {
                seatType=(SeatType)i;
                checkbox = new CheckBox();
                checkbox.Name = "chk" + seatType.ToString();
                checkbox.Tag = seatType;
                checkbox.Text = SeatTypeDescriptionHelper.Description[seatType];
                checkbox.AutoSize = true;
                checkbox.CheckedChanged += new EventHandler(checkbox_CheckedChanged);
                checkbox.Checked = true;
                flpSeatTypies.Controls.Add(checkbox);
            }
        }

        void checkbox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            SeatType seatType = (SeatType)checkBox.Tag;
            if (checkBox.Checked == true)
            {
                if (selectedSeatType.Contains(seatType) == false)
                {
                    selectedSeatType.Add(seatType);
                }
            }
            else
            {
                if (selectedSeatType.Contains(seatType) == true)
                {
                    selectedSeatType.Remove(seatType);
                } 
            }
            dgvTiketInfo.Refresh();
        }

        /// <summary>
        /// 列车始发/经过类型
        /// </summary>
        private void initTrainPassType()
        {
            CheckBox chkQB = new CheckBox();
            chkQB.Name = "chkQB";
            chkQB.Tag = "QB";
            chkQB.Text = "全部";
            chkQB.AutoSize = true;
            chkQB.CheckedChanged += new EventHandler(chkTrainPassType_CheckedChanged);
            flpTrainPassType.Controls.Add(chkQB);

            CheckBox chkGL = new CheckBox();
            chkGL.Name = "chkGL";
            chkGL.Tag = "GL";
            chkGL.Text = "过路";
            chkGL.AutoSize = true;
            chkGL.CheckedChanged += new EventHandler(chkTrainPassType_CheckedChanged);
            flpTrainPassType.Controls.Add(chkGL);

            CheckBox chkSF = new CheckBox();
            chkSF.Name = "chkSF";
            chkSF.Tag = "SF";
            chkSF.Text = "始发";
            chkSF.AutoSize = true;
            chkSF.CheckedChanged += new EventHandler(chkTrainPassType_CheckedChanged);
            flpTrainPassType.Controls.Add(chkSF);

            chkQB.Checked = true;
        }

        void chkTrainPassType_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox currentCheckBox = sender as CheckBox;
            CheckBox selectAllCheckBox = flpTrainPassType.Controls["chkQB"] as CheckBox;
            Control.ControlCollection checkboxCollection = flpTrainPassType.Controls;
            CommUitl.SelectAllChkChange(currentCheckBox, selectAllCheckBox, checkboxCollection);
        }
        #endregion

        #region 初始化常量
        private static string Stations
        {
            get
            {
                // 使用本地车站信息.不从WEB取
                //stations = stations_buffer;
                if (string.IsNullOrEmpty(stations) == true)
                {
                    try
                    {
                        stations = CommUitl.getString("https://dynamic.12306.cn/otsweb/js/common/station_name.js");
                        stations = stations.Replace("var station_names ='", string.Empty);
                        stations = stations.Replace("';", string.Empty);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                        stations = stations_buffer;
                    }
                }
                return stations;
            }
        }

        private static List<KeyValuePair<string, string>> TrainTypies
        {
            get
            {
                if (ticketTypies == null)
                {
                    ticketTypies = new List<KeyValuePair<string, string>>();
                    ticketTypies.Add(new KeyValuePair<string, string>("QB", "全部"));
                    ticketTypies.Add(new KeyValuePair<string, string>("D", "动车"));
                    ticketTypies.Add(new KeyValuePair<string, string>("Z", "Z字头"));
                    ticketTypies.Add(new KeyValuePair<string, string>("T", "T字头"));
                    ticketTypies.Add(new KeyValuePair<string, string>("K", "K字头"));
                    ticketTypies.Add(new KeyValuePair<string, string>("QT", "其他"));
                }
                return ticketTypies;
            }
        }
        /// <summary>
        /// 目的地
        /// </summary>
        private static List<Station> DestinationStations
        {
            get
            {
                if (destinationStations == null)
                {
                    destinationStations = new List<Station>();
                    string[] citiesArray = Stations.Split('@');
                    string[] cityItem;
                    for (int i = 1; i < citiesArray.Length; i++)
                    {
                        cityItem = citiesArray[i].Split('|');
                        destinationStations.Add(new Station(cityItem[0],cityItem[1],cityItem[2],Convert.ToInt32(cityItem[3])));
                    }
                }
                return destinationStations;
            }
        }

        /// <summary>
        /// 出发地
        /// </summary>
        private static List<Station> DepartureStations
        {
            get
            {
                if (departureStations == null)
                {
                    departureStations = new List<Station>();
                    string[] citiesArray = Stations.Split('@');
                    string[] cityItem;
                    for (int i = 1; i < citiesArray.Length; i++)
                    {
                        cityItem = citiesArray[i].Split('|');
                        departureStations.Add(new Station(cityItem[0], cityItem[1], cityItem[2], Convert.ToInt32(cityItem[3])));
                    }
                }
                return departureStations;
            }
        }

        /// <summary>
        /// 出发时间
        /// </summary>
        private static List<string> DepartureTimes
        {
            get
            {
                if (departureTimes == null)
                {
                    departureTimes = new List<string>();
                    departureTimes.Add("00:00--24:00");
                    departureTimes.Add("00:00--06:00");
                    departureTimes.Add("06:00--12:00");
                    departureTimes.Add("12:00--18:00");
                    departureTimes.Add("18:00--24:00");
                }
                return departureTimes;
            }
        }
        #endregion

        #region 查询列车信息
        private void btnQuery_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                getTicketInfos();
                labTicketInfo.Text = getTicketInfo(dtpDepartureDate.Value, cboDepartureStation.Text, cboDestinationStation.Text, ticketInfoList.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// 查询车票信息
        /// </summary>
        private void getTicketInfos()
        {

            // https://dynamic.12306.cn/otsweb/order/querySingleAction.do?method=queryLeftTicket&
            // orderRequest.train_date=2012-02-24&
            // orderRequest.from_station_telecode=IZQ&
            // orderRequest.to_station_telecode=IOQ&
            // orderRequest.train_no=6c000G620100&
            // trainPassType=QB&
            // trainClass=QB%23D%23Z%23T%23K%23QT%23&   // trainClass=D%23Z%23T%23&
            // includeStudent=00&
            // seatTypeAndNum=&
            // orderRequest.start_time_str=00%3A00--24%3A00
            string url = "https://dynamic.12306.cn/otsweb/order/querySingleAction.do?" +
                "method=queryLeftTicket" +
                "&orderRequest.train_date=" + dtpDepartureDate.Value.ToString("yyyy-MM-dd") +
                "&orderRequest.from_station_telecode=" + cboDepartureStation.SelectedValue +
                "&orderRequest.to_station_telecode=" + cboDestinationStation.SelectedValue +
                "&orderRequest.train_no=" + cboTrainNumber.SelectedValue +
                "&trainPassType=" + getTrainPassType() +
                "&trainClass=" + HttpUtility.UrlEncode(getTrainClass()) +
                "&includeStudent=00" +
                "&seatTypeAndNum=" +
                "&orderRequest.start_time_str=" + cboDepartureTime.SelectedValue;
            string result = CommUitl.getString(url, CommData.cookieContainer);
            //result = "0,<span id='id_65000K921210' class='base_txtdiv' onmouseover=javascript:onStopHover('65000K921210#SZQ#CSQ') onmouseout='onStopOut()'>K9212</span>,<img src='/otsweb/images/tips/first.gif'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;深圳&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;09:14,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;长沙&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;19:55,10:41,--,--,--,--,--,--,--,--,<font color='darkgray'>无</font>,<font color='darkgray'>无</font>,--,<input type='button' class='yuding_x'  value='预订'></input>\n1,<span id='id_69000K906405' class='base_txtdiv' onmouseover=javascript:onStopHover('69000K906405#OSQ#CSQ') onmouseout='onStopOut()'>K9064</span>,<img src='/otsweb/images/tips/first.gif'>&nbsp;&nbsp;&nbsp;&nbsp;深圳西&nbsp;&nbsp;&nbsp;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;11:26,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;长沙&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;22:03,10:37,--,--,--,--,--,--,<font color='darkgray'>无</font>,--,<font color='darkgray'>无</font>,<font color='darkgray'>无</font>,--,<input type='button' class='yuding_x'  value='预订'></input>\n2,<span id='id_65000K116810' class='base_txtdiv' onmouseover=javascript:onStopHover('65000K116810#SZQ#CSQ') onmouseout='onStopOut()'>K1168</span>,<img src='/otsweb/images/tips/first.gif'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;深圳&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;15:15,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;长沙&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;04:23,13:08,--,--,--,--,--,--,--,--,<font color='darkgray'>无</font>,<font color='darkgray'>无</font>,--,<input type='button' class='yuding_x'  value='预订'></input>\n3,<span id='id_6500000T9607' class='base_txtdiv' onmouseover=javascript:onStopHover('6500000T9607#SZQ#CSQ') onmouseout='onStopOut()'>T96</span>,<img src='/otsweb/images/tips/first.gif'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;深圳&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;17:40,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;长沙&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;02:43,09:03,--,--,--,--,--,<font color='darkgray'>无</font>,<font color='darkgray'>无</font>,--,<font color='darkgray'>无</font>,<font color='darkgray'>无</font>,--,<input type='button' class='yuding_x'  value='预订'></input>\n4,<span id='id_65000K900402' class='base_txtdiv' onmouseover=javascript:onStopHover('65000K900402#SZQ#CSQ') onmouseout='onStopOut()'>K9004</span>,<img src='/otsweb/images/tips/first.gif'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;深圳&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;19:20,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;长沙&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;05:50,10:30,--,--,--,--,--,<font color='darkgray'>无</font>,<font color='darkgray'>无</font>,--,<font color='darkgray'>无</font>,<font color='darkgray'>无</font>,--,<input type='button' class='yuding_x'  value='预订'></input>\n5,<span id='id_65000K907606' class='base_txtdiv' onmouseover=javascript:onStopHover('65000K907606#SZQ#CSQ') onmouseout='onStopOut()'>K9076</span>,<img src='/otsweb/images/tips/first.gif'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;深圳&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;19:36,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;长沙&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;05:44,10:08,--,--,--,--,--,<font color='darkgray'>无</font>,<font color='darkgray'>无</font>,--,<font color='darkgray'>无</font>,<font color='darkgray'>无</font>,--,<input type='button' class='yuding_x'  value='预订'></input>\n6,<span id='id_65000K901803' class='base_txtdiv' onmouseover=javascript:onStopHover('65000K901803#SZQ#CSQ') onmouseout='onStopOut()'>K9018</span>,<img src='/otsweb/images/tips/first.gif'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;深圳&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;20:50,<img src='/otsweb/images/tips/last.gif'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;长沙&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;06:36,09:46,--,--,--,--,--,<font color='darkgray'>无</font>,<font color='darkgray'>无</font>,--,<font color='darkgray'>无</font>,<font color='darkgray'>无</font>,--,<input type='button' class='yuding_x'  value='预订'></input>\n7,<span id='id_69000K921400' class='base_txtdiv' onmouseover=javascript:onStopHover('69000K921400#OSQ#CSQ') onmouseout='onStopOut()'>K9214</span>,<img src='/otsweb/images/tips/first.gif'>&nbsp;&nbsp;&nbsp;&nbsp;深圳西&nbsp;&nbsp;&nbsp;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;23:55,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;长沙&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>&nbsp;&nbsp;&nbsp;&nbsp;10:21,10:26,--,--,--,--,--,--,--,--,<font color='darkgray'>无</font>,<font color='darkgray'>无</font>,--,<input type='button' class='yuding_x'  value='预订'></input>";
            if (result.IndexOf("系统维护中") > 0)
            {
                MessageBox.Show("系统维护中!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                dgvTiketInfo.DataSource = getTicketInfos(result);
            }
        }

        /// <summary>
        /// 根据WEB返回结果生成实体列表
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private static BindingList<TicketInfo> getTicketInfos(string result)
        {
            if (ticketInfoList == null)
            {
                ticketInfoList = new BindingList<TicketInfo>();
            } 
            ticketInfoList.Clear();
            int numResult;
            if (int.TryParse(result,out numResult)==false)
            {
                Dictionary<string, string> jsInfos = getJsInfo(result);
                result = CommUitl.ReplaceHTMLAttributes(result);
                string[] ticketInfoStrs = result.Split(new string[] { "\\n" }, StringSplitOptions.RemoveEmptyEntries);
                string[] ticketInfos;
                string[] stations;
                TicketInfo ticketInfo;
                for (int i = 0; i < ticketInfoStrs.Length; i++)
                {
                    ticketInfos = ticketInfoStrs[i].Split(',');
                    ticketInfo = new TicketInfo();
                    ticketInfo.ID = Convert.ToInt32(ticketInfos[0]);
                    ticketInfo.StationTrainCode = ticketInfos[1];
                    stations = ticketInfos[2].Replace("  ", " ").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    ticketInfo.DepartureStation = stations[0];
                    ticketInfo.DrivingTime = stations[1];
                    stations = ticketInfos[3].Replace("  ", " ").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    ticketInfo.DestinationStation = stations[0];
                    ticketInfo.ArrivalTime = stations[1];
                    ticketInfo.ElapsedTime = ticketInfos[4];
                    //ticketInfo.SeetInfos = new Dictionary<SeatType, string>();
                    //for (int j = 0; j < 11; j++)
                    //{
                    //    ticketInfo.SeetInfos.Add((SeatType)j, ticketInfos[j + 5]);
                    //    //Debug.WriteLine("ticketInfo." + (SeatType)j + "=ticketInfos["+(j + 5)+"];");
                    //}
                    ticketInfo.BusinessBlock = ticketInfos[5];
                    ticketInfo.PrincipalSeat = ticketInfos[6];
                    ticketInfo.FirstClassSeat = ticketInfos[7];
                    ticketInfo.SecondClassSeat = ticketInfos[8];
                    ticketInfo.AdvancedSoftSleeper = ticketInfos[9];
                    ticketInfo.SoftSleeper = ticketInfos[10];
                    ticketInfo.HardSleeper = ticketInfos[11];
                    ticketInfo.SoftSeat = ticketInfos[12];
                    ticketInfo.HardSeat = ticketInfos[13];
                    ticketInfo.NoSeat = ticketInfos[14];
                    ticketInfo.Other = ticketInfos[15];
                    try
                    {
                        ticketInfo.JsInfoString = jsInfos[ticketInfo.StationTrainCode];
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                    ticketInfoList.Add(ticketInfo);
                }
            }
            return ticketInfoList;
        }

        /// <summary>
        /// 得到预订按钮对应的JS提交信息
        /// </summary>
        /// <param name="webResult"></param>
        /// <returns></returns>
        private static Dictionary<string,string> getJsInfo(string webResult)
        {
            string[] tmpRsult;
            Dictionary<string,string> result=new Dictionary<string,string>();
            string jsInfo;
            tmpRsult = webResult.Split(new string[] { "javascript:getSelected('" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < tmpRsult.Length; i++)
            {
                if (tmpRsult[i].IndexOf("') value='预订'") > -1)
                {
                    jsInfo = tmpRsult[i].Split(new string[] { "') value='预订'" }, StringSplitOptions.RemoveEmptyEntries)[0];
                    result.Add(jsInfo.Split('#')[0], jsInfo);
                }
            }
            return result;
        }

        /// <summary>
        /// 得到列车类型选项
        /// </summary>
        /// <returns></returns>
        private string getTrainClass()
        {
            string result=string.Empty;
            CheckBox chk;
            foreach (var item in flpTrainType.Controls)
            {
                if (item is CheckBox)
                {
                    chk = item as CheckBox;
                    if (chk.Checked == true)
                    {
                        result += chk.Tag + "#";
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 得到列车始发/经过选项
        /// </summary>
        /// <returns></returns>
        private string getTrainPassType()
        {
            string result = string.Empty;
            CheckBox chk;
            foreach (var item in flpTrainPassType.Controls)
            {
                if (item is CheckBox)
                {
                    chk = item as CheckBox;
                    if (chk.Checked == true)
                    {
                        result = chk.Tag.ToString();
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 查询结果信息
        /// </summary>
        /// <param name="departureDate"></param>
        /// <param name="departureStationName"></param>
        /// <param name="destinationStationName"></param>
        /// <param name="trainCount"></param>
        /// <returns></returns>
        private string getTicketInfo(DateTime departureDate, string departureStationName, string destinationStationName, int trainCount)
        {
            string result;
            result = string.Format("出发日期：{0}    {1}→{2}(共 {3} 趟列车)",departureDate.ToString("yyyy-MM-dd"),departureStationName,destinationStationName,trainCount);
            return result;
        }
        #endregion


        #region 根据出发站及到站行李相应的列车信息
        private void cboTrainNumber_Enter(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (trainNumbers.Count <= 1)
                {
                    if (cboDepartureStation.SelectedValue == null)
                    {
                        MessageBox.Show("请选择出发站!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (cboDestinationStation.SelectedValue == null)
                    {
                        MessageBox.Show("请选择目的站!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string url = "https://dynamic.12306.cn/otsweb/order/querySingleAction.do?method=queryststrainall";
                        List<KeyValuePair<string, string>> postData = new List<KeyValuePair<string, string>>();
                        postData.Add(new KeyValuePair<string, string>("date", dtpDepartureDate.Value.ToString("yyyy-MM-dd")));
                        postData.Add(new KeyValuePair<string, string>("fromstation", cboDepartureStation.SelectedValue.ToString()));
                        postData.Add(new KeyValuePair<string, string>("tostation", cboDestinationStation.SelectedValue.ToString()));
                        postData.Add(new KeyValuePair<string, string>("starttime", cboDepartureTime.SelectedValue.ToString()));
                        string webResult = CommUitl.postString(url, postData, null, null, Encoding.UTF8, CommData.cookieCollection, "https://dynamic.12306.cn/otsweb/order/querySingleAction.do?method=init");

                        string message = getMessage(webResult);
                        if (string.IsNullOrEmpty(message) == false)
                        {
                            MessageBox.Show(message);
                        }
                        else
                        {
                            trainNumbers = getTrainNumber(webResult);
                            cboTrainNumber.DataSource = null;
                            cboTrainNumber.DataSource = trainNumbers;
                            cboTrainNumber.ValueMember = "key";
                            cboTrainNumber.DisplayMember = "value";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// 根据web返回结果得到对应的车次信息-用于下拉框
        /// </summary>
        /// <param name="webResult"></param>
        /// <returns></returns>
        private List<KeyValuePair<string, string>> getTrainNumber(string webResult)
        {
            resetTrainNumers();
            //测试数据
            //webResult = "[{\"end_station_name\":\"深圳北\",\"end_time\":\"07:44\",\"id\":\"6c000G620100\",\"start_station_name\":\"广州南\",\"start_time\":\"07:00\",\"value\":\"G6201\"},{\"end_station_name\":\"深圳北\",\"end_time\":\"08:06\",\"id\":\"6c000G620300\",\"start_station_name\":\"广州南\",\"start_time\":\"07:30\",\"value\":\"G6203\"},{\"end_station_name\":\"深圳北\",\"end_time\":\"08:44\",\"id\":\"6c000G620500\",\"start_station_name\":\"广州南\",\"start_time\":\"08:00\",\"value\":\"G6205\"},{\"end_station_name\":\"深圳北\",\"end_time\":\"09:03\",\"id\":\"6c000G620700\",\"start_station_name\":\"广州南\",\"start_time\":\"08:20\",\"value\":\"G6207\"},{\"end_station_name\":\"深圳北\",\"end_time\":\"09:16\",\"id\":\"6c000G620900\",\"start_station_name\":\"广州南\",\"start_time\":\"08:40\",\"value\":\"G6209\"},{\"end_station_name\":\"深圳北\",\"end_time\":\"09:36\",\"id\":\"6c000G621100\",\"start_station_name\":\"广州南\",\"start_time\":\"09:00\",\"value\":\"G6211\"},{\"end_station_name\":\"深圳北\",\"end_time\":\"10:06\",\"id\":\"6c000G621300\",\"start_station_name\":\"广州南\",\"start_time\":\"09:30\",\"value\":\"G6213\"},{\"end_station_name\":\"深圳北\",\"end_time\":\"10:44\",\"id\":\"6c000G621500\",\"start_station_name\":\"广州南\",\"start_time\":\"10:00\",\"value\":\"G6215\"},{\"end_station_name\":\"深圳北\",\"end_time\":\"10:56\",\"id\":\"6c000G621700\",\"start_station_name\":\"广州南\",\"start_time\":\"10:20\",\"value\":\"G6217\"},{\"end_station_name\":\"深圳北\",\"end_time\":\"11:16\",\"id\":\"6c000G621900\",\"start_station_name\":\"广州南\",\"start_time\":\"10:40\",\"value\":\"G6219\"},{\"end_station_name\":\"深圳北\",\"end_time\":\"11:36\",\"id\":\"6c000G622100\",\"start_station_name\":\"广州南\",\"start_time\":\"11:00\",\"value\":\"G6221\"},{\"end_station_name\":\"深圳北\",\"end_time\":\"12:13\",\"id\":\"6c000G622300\",\"start_station_name\":\"广州南\",\"start_time\":\"11:30\",\"value\":\"G6223\"},{\"end_station_name\":\"深圳北\",\"end_time\":\"12:44\",\"id\":\"6c000G622500\",\"start_station_name\":\"广州南\",\"start_time\":\"12:00\",\"value\":\"G6225\"},{\"end_station_name\":\"深圳北\",\"end_time\":\"12:56\",\"id\":\"6c000G622700\",\"start_station_name\":\"广州南\",\"start_time\":\"12:20\",\"value\":\"G6227\"},{\"end_station_name\":\"深圳北\",\"end_time\":\"13:26\",\"id\":\"6c000G622900\",\"start_station_name\":\"广州南\",\"start_time\":\"12:50\",\"value\":\"G6229\"},{\"end_station_name\":\"深圳北\",\"end_time\":\"13:46\",\"id\":\"6c000G623100\",\"start_station_name\":\"广州南\",\"start_time\":\"13:10\",\"value\":\"G6231\"},{\"end_station_name\":\"深圳北\",\"end_time\":\"14:06\",\"id\":\"6c000G623300\",\"start_station_name\":\"广州南\",\"start_time\":\"13:30\",\"value\":\"G6233\"},{\"end_station_name\":\"深圳北\",\"end_time\":\"14:44\",\"id\":\"6c000G623500\",\"start_station_name\":\"广州南\",\"start_time\":\"14:00\",\"value\":\"G6235\"},{\"end_station_name\":\"深圳北\",\"end_time\":\"15:03\",\"id\":\"6c000G623700\",\"start_station_name\":\"广州南\",\"start_time\":\"14:20\",\"value\":\"G6237\"},{\"end_station_name\":\"深圳北\",\"end_time\":\"15:26\",\"id\":\"6c000G623900\",\"start_station_name\":\"广州南\",\"start_time\":\"14:50\",\"value\":\"G6239\"},{\"end_station_name\":\"深圳北\",\"end_time\":\"15:46\",\"id\":\"6c000G624100\",\"start_station_name\":\"广州南\",\"start_time\":\"15:10\",\"value\":\"G6241\"},{\"end_station_name\":\"深圳北\",\"end_time\":\"16:16\",\"id\":\"6c000G624300\",\"start_station_name\":\"广州南\",\"start_time\":\"15:40\",\"value\":\"G6243\"},{\"end_station_name\":\"深圳北\",\"end_time\":\"16:44\",\"id\":\"6c000G624500\",\"start_station_name\":\"广州南\",\"start_time\":\"16:00\",\"value\":\"G6245\"},{\"end_station_name\":\"深圳北\",\"end_time\":\"16:56\",\"id\":\"6c000G624700\",\"start_station_name\":\"广州南\",\"start_time\":\"16:20\",\"value\":\"G6247\"},{\"end_station_name\":\"深圳北\",\"end_time\":\"17:16\",\"id\":\"6c000G624900\",\"start_station_name\":\"广州南\",\"start_time\":\"16:40\",\"value\":\"G6249\"},{\"end_station_name\":\"深圳北\",\"end_time\":\"17:46\",\"id\":\"6c000G625100\",\"start_station_name\":\"广州南\",\"start_time\":\"17:10\",\"value\":\"G6251\"},{\"end_station_name\":\"深圳北\",\"end_time\":\"18:16\",\"id\":\"6c000G625300\",\"start_station_name\":\"广州南\",\"start_time\":\"17:40\",\"value\":\"G6253\"},{\"end_station_name\":\"深圳北\",\"end_time\":\"18:44\",\"id\":\"6c000G625500\",\"start_station_name\":\"广州南\",\"start_time\":\"18:00\",\"value\":\"G6255\"},{\"end_station_name\":\"深圳北\",\"end_time\":\"19:03\",\"id\":\"6c000G625700\",\"start_station_name\":\"广州南\",\"start_time\":\"18:20\",\"value\":\"G6257\"},{\"end_station_name\":\"深圳北\",\"end_time\":\"19:26\",\"id\":\"6c000G625900\",\"start_station_name\":\"广州南\",\"start_time\":\"18:50\",\"value\":\"G6259\"},{\"end_station_name\":\"深圳北\",\"end_time\":\"19:56\",\"id\":\"6c000G626100\",\"start_station_name\":\"广州南\",\"start_time\":\"19:20\",\"value\":\"G6261\"},{\"end_station_name\":\"深圳北\",\"end_time\":\"20:16\",\"id\":\"6c000G626300\",\"start_station_name\":\"广州南\",\"start_time\":\"19:40\",\"value\":\"G6263\"},{\"end_station_name\":\"深圳北\",\"end_time\":\"20:54\",\"id\":\"6c000G626500\",\"start_station_name\":\"广州南\",\"start_time\":\"20:10\",\"value\":\"G6265\"},{\"end_station_name\":\"深圳北\",\"end_time\":\"21:05\",\"id\":\"6c000G628503\",\"start_station_name\":\"广州南\",\"start_time\":\"20:28\",\"value\":\"G6285\"},{\"end_station_name\":\"深圳北\",\"end_time\":\"21:16\",\"id\":\"6c000G626700\",\"start_station_name\":\"广州南\",\"start_time\":\"20:40\",\"value\":\"G6267\"},{\"end_station_name\":\"深圳北\",\"end_time\":\"21:56\",\"id\":\"6c000G626900\",\"start_station_name\":\"广州南\",\"start_time\":\"21:20\",\"value\":\"G6269\"},{\"end_station_name\":\"深圳北\",\"end_time\":\"22:51\",\"id\":\"6c000G627100\",\"start_station_name\":\"广州南\",\"start_time\":\"22:00\",\"value\":\"G6271\"}]";
            if (string.IsNullOrEmpty(webResult) == false)
            {
                webResult = webResult.Replace("\"", string.Empty);
                webResult = webResult.Replace("[", string.Empty);
                webResult = webResult.Replace("]", string.Empty);
                webResult = webResult.Replace("{", string.Empty);
                //删除最后一个}号
                webResult = webResult.Substring(0, webResult.Length - 1);
                string[] results = webResult.Split(new string[] { "}," }, StringSplitOptions.RemoveEmptyEntries);
                string[] trainNumberInfo;
                string key;
                // G6201（广州南07:00→深圳北07:44）
                string value;
                for (int i = 0; i < results.Length; i++)
                {
                    trainNumberInfo = results[i].Split(',');
                    key = trainNumberInfo[2].Split(':')[1];
                    value = string.Format("{0}（{1}{2}→{3}{4}）", trainNumberInfo[5].Split(':')[1], trainNumberInfo[3].Split(':')[1], trainNumberInfo[4].Split(':')[1], trainNumberInfo[5].Split(':')[1], trainNumberInfo[0].Split(':')[1], trainNumberInfo[1].Split(':')[1]);
                    trainNumbers.Add(new KeyValuePair<string, string>(key, value));
                }
            }
            return trainNumbers;
        }

        private void cboDepartureStation_SelectedValueChanged(object sender, EventArgs e)
        {
            resetTrainNumers();
        }

        private void cboDestinationStation_SelectedValueChanged(object sender, EventArgs e)
        {
            resetTrainNumers();
        }

        /// <summary>
        /// 重置列车信息
        /// </summary>
        private void resetTrainNumers()
        {
            trainNumbers.Clear();
            trainNumbers.Add(new KeyValuePair<string,string>(string.Empty,"不限"));
        }
        #endregion

        private void btnMoreOption_Click(object sender, EventArgs e)
        {
            changeMoreOption();
        }

        private void changeMoreOption()
        {
            int height;
            string btnText;
            if (btnMoreOption.Text == "高级查询")
            {
                height = 30;
                btnText = "简单查询";
            }
            else
            {
                height = 0;
                btnText = "高级查询";
            }

            tlpMain.RowStyles[1].Height = height;
            tlpMain.RowStyles[2].Height = height;
            btnMoreOption.Text = btnText;
        }

        private void tssAuthor_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.9inf.com");
        }

        #region 预订
        //javascript:getSelected('2252#00:23#10:50#12000022580I#TAP#BJP#11:13#通州西#北京#1000700174300580000340083000141000703491')
        //function getSelected(selectStr) {
        //var selectStr_arr = selectStr.split("#");
        //var station_train_code=selectStr_arr[0];
        //var lishi=selectStr_arr[1];
        //var starttime=selectStr_arr[2];
        //var trainno=selectStr_arr[3];
        //var from_station_telecode=selectStr_arr[4];
        //var to_station_telecode=selectStr_arr[5];
        //var arrive_time=selectStr_arr[6];
        //var from_station_name=selectStr_arr[7];
        //var to_station_name=selectStr_arr[8];
        //var ypInfoDetail=selectStr_arr[9];
        //var flag = true;
        //if (checkBeyondMixTicketNum()) {
        //flag = false;
        //return;
        //}
        //// 该方法在各个页面中分别书写，因为根据页面的不同行为不同，相当于重写
        //if (flag) {
        //submitRequest(station_train_code,lishi,starttime,trainno,from_station_telecode,to_station_telecode,arrive_time,from_station_name,to_station_name,ypInfoDetail);
        //} 

        //station_train_code	L43
        //train_date	2012-01-15
        //seattype_num	
        //from_station_telecode	BXP
        //to_station_telecode	CSQ
        //include_student	00
        //from_station_telecode_name	北京
        //to_station_telecode_name	长沙
        //round_train_date	2012-01-05
        //round_start_time_str	00:00--24:00
        //single_round_type	1
        //train_pass_type	QB
        //train_class_arr	QB#D#Z#T#K#QT#
        //start_time_str	00:00--24:00
        //lishi	20:19
        //train_start_time	02:23
        //trainno	2400000L430A
        //arrive_time	22:42
        //from_station_name	北京西
        //to_station_name	长沙
        //ypInfoDetail	101680000120278000001016803666

        string token;

        private void booking(TicketInfo ticketInfo)
        {
            // 得到验证码路径  https://dynamic.12306.cn/otsweb/passCodeAction.do?rand=randp

            List<KeyValuePair<string, string>> postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string,string>("station_train_code", ticketInfo.StationTrainCode));
            postData.Add(new KeyValuePair<string,string>("train_date", DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")));
            postData.Add(new KeyValuePair<string,string>("seattype_num", string.Empty));
            postData.Add(new KeyValuePair<string,string>("from_station_telecode", ticketInfo.DepartureStationTelCode));
            postData.Add(new KeyValuePair<string,string>("to_station_telecode", ticketInfo.DestinationStationTelCode));
            postData.Add(new KeyValuePair<string,string>("include_student", "00"));
            postData.Add(new KeyValuePair<string,string>("from_station_telecode_name", ticketInfo.DepartureStation));
            postData.Add(new KeyValuePair<string,string>("to_station_telecode_name", ticketInfo.DestinationStation));
            postData.Add(new KeyValuePair<string,string>("round_train_date", DateTime.Now.ToString("yyyy-MM-dd")));
            postData.Add(new KeyValuePair<string,string>("round_start_time_str", "00:00--24:00"));
            //单程 1 返程 2
            postData.Add(new KeyValuePair<string,string>("single_round_type", "1"));
            postData.Add(new KeyValuePair<string,string>("train_pass_type", "QB"));
            postData.Add(new KeyValuePair<string,string>("train_class_arr", "QB#D#Z#T#K#QT#"));
            postData.Add(new KeyValuePair<string,string>("start_time_str", "00:00--24:00"));
            postData.Add(new KeyValuePair<string,string>("lishi", ticketInfo.ElapsedTime));
            postData.Add(new KeyValuePair<string,string>("train_start_time", ticketInfo.DrivingTime));
            postData.Add(new KeyValuePair<string,string>("trainno", ticketInfo.TrainNo));
            postData.Add(new KeyValuePair<string,string>("arrive_time", ticketInfo.ArrivalTime));
            postData.Add(new KeyValuePair<string,string>("from_station_name", ticketInfo.DepartureStation));
            postData.Add(new KeyValuePair<string,string>("to_station_name", ticketInfo.DestinationStation));
            postData.Add(new KeyValuePair<string,string>("ypInfoDetail", ticketInfo.InfoDetail));
            postData.Add(new KeyValuePair<string, string>("mmStr", ticketInfo.MmStr));
            //// 列车编号
            //param.Add(new KeyValuePair<string,string>("station_train_code", ticketInfo.StationTrainCode);
            //// 列车编号
            //param.Add(new KeyValuePair<string,string>("train_date", DateTime.Now.ToString("yyyy-MM-dd"));
            //param.Add(new KeyValuePair<string,string>("seattype_num", string.Empty);
            //// 出发站编号
            //param.Add(new KeyValuePair<string,string>("from_station_telecode", ticketInfo.DepartureStationTelCode);
            //// 到站编号
            //param.Add(new KeyValuePair<string,string>("to_station_telecode", ticketInfo.DestinationStationTelCode);
            //// 学生票
            //param.Add(new KeyValuePair<string,string>("include_student", "00");
            //// 到站
            //param.Add(new KeyValuePair<string,string>("to_station_telecode_name", ticketInfo.DestinationStation);
            //// 返程日期
            //param.Add(new KeyValuePair<string,string>("round_train_date", DateTime.Now.ToString("yyyy-MM-dd"));
            //// 发站
            //param.Add(new KeyValuePair<string,string>("from_station_name", ticketInfo.DepartureStation);
            //// 到站
            //param.Add(new KeyValuePair<string,string>("to_station_name", ticketInfo.DestinationStation);
            //// 返程时间段
            //param.Add(new KeyValuePair<string,string>("round_start_time_str", "00:00--24:00");
            ////单程 1 返程 2
            //param.Add(new KeyValuePair<string,string>("single_round_type", "1");
            //// 列车路过的类型
            //param.Add(new KeyValuePair<string,string>("train_pass_type", "QB");
            //// 座位类型
            //param.Add(new KeyValuePair<string,string>("train_class_arr", "QB#D#Z#T#K#QT#");
            //// 时间段
            //param.Add(new KeyValuePair<string,string>("start_time_str", "00:00--24:00");
            //// 历时
            //param.Add(new KeyValuePair<string,string>("lishi", ticketInfo.ElapsedTime);
            //// 开车时间
            //param.Add(new KeyValuePair<string,string>("train_start_time", ticketInfo.DrivingTime);
            //// 列车编号
            //param.Add(new KeyValuePair<string,string>("trainno", ticketInfo.TrainNo);
            //// 到达时间
            //param.Add(new KeyValuePair<string,string>("arrive_time", ticketInfo.ArrivalTime);
            //// 
            //param.Add(new KeyValuePair<string,string>("ypInfoDetail", ticketInfo.InfoDetail);
            try
            {
                string webResult = CommUitl.postString(submutOrderRequestUrl, postData, null, null, Encoding.UTF8, CommData.cookieCollection, "https://dynamic.12306.cn/otsweb/order/querySingleAction.do?method=init");
                string message = getMessage(webResult);
                if (string.IsNullOrEmpty(message) == false)
                {
                    MessageBox.Show(message);
                }
                else
                {
                    initFlpPassenger(getPassenger(webResult));
                    token = getToken(webResult);
                    rtbTrainInfo.Text = getTicketInfo(webResult);
                    //string webResult1 = CommUitl.getString("https://dynamic.12306.cn/otsweb/order/confirmPassengerAction.do?method=init", CommData.cookieContainer, "https://dynamic.12306.cn/otsweb/order/querySingleAction.do?method=init");
                    //列车信息
//webResult.IndexOf("#F3F8FC",0)
//8100
//webResult.Substring(8100,100)
//"#F3F8FC\">\r\n\t\t\t\t<td class=\"bluetext\">2012年03月04日</td>\r\n\t\t\t\t<td class=\"bluetext\">6417次</td>\r\n\t\t\t\t<td c"
//webResult.IndexOf("以上余票信息随时发生变化，仅作参考",8100)
//8517
//webResult.Substring(8100,417)
//"#F3F8FC\">\r\n\t\t\t\t<td class=\"bluetext\">2012年03月04日</td>\r\n\t\t\t\t<td class=\"bluetext\">6417次</td>\r\n\t\t\t\t<td class=\"bluetext\">北京（16:22 开 ）</td>\r\n\t\t\t\t<td class=\"bluetext\">通州西（16:50到 ）</td>\r\n\t\t\t\t\r\n\t\t\t\t<td class=\"bluetext\">历时（00:28）</td>\r\n\t\t\t</tr>\r\n         \r\n            \r\n\t\t\t\r\n\t\t\t    <tr>\r\n\t\t\t\r\n\t\t\t\t<td>硬座(1.50元)有票</td>\r\n\t\t\r\n            \r\n\t\t\t\r\n\t\t\t\t<td>无座(1.50元)有票</td>\r\n\t\t\r\n\t\t</tr>\r\n\t\t\t<tr>\r\n\t\t\t\t<td colspan=\"5\" class=\"redtext\">"
//CommUitl.ReplaceHTMLAttributes(webResult.Substring(8100,417))
//"#F3F8FC\">\r\n\t\t\t\t2012年03月04日\r\n\t\t\t\t6417次\r\n\t\t\t\t北京（16:22 开 ）\r\n\t\t\t\t通州西（16:50到 ）\r\n\t\t\t\t\r\n\t\t\t\t历时（00:28）\r\n\t\t\t\r\n         \r\n            \r\n\t\t\t\r\n\t\t\t    \r\n\t\t\t\r\n\t\t\t\t硬座(1.50元)有票\r\n\t\t\r\n            \r\n\t\t\t\r\n\t\t\t\t无座(1.50元)有票\r\n\t\t\r\n\t\t\r\n\t\t\t\r\n\t\t\t\t"

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string getTicketInfo(string webResult)
        {
            string result = string.Empty;
            int startInt;
            string keyword="<tr style=\"background-color:#F3F8FC\">";
            startInt = webResult.IndexOf(keyword);
            if (startInt > -1)
            {
                startInt+=keyword.Length;
                int endInt;
                endInt = webResult.IndexOf("以上余票信息随时发生变化，仅作参考", startInt);
                result = webResult.Substring(startInt, endInt);
                result = CommUitl.ReplaceHTMLAttributes(webResult.Substring(startInt, endInt - startInt)).Replace("\r\n", string.Empty).Replace("\t", string.Empty);
                Regex re = new Regex(@"[/s]{2,}", RegexOptions.Compiled);
                result = Regex.Replace(result.Trim(), "\\s+", " ");
            }
            return result;
        }
        #endregion

        /// <summary>
        /// 得到Token
        /// </summary>
        /// <param name="webResult"></param>
        /// <returns></returns>
        private string getToken(string webResult)
        {
            string result = string.Empty;
            int startInd;
            int endInd;
            if (webResult.IndexOf("TOKEN\" value=") > -1)
            {
                startInd = webResult.IndexOf("TOKEN\" value=") + "TOKEN\" value=".Length + 1;
                endInd = webResult.IndexOf("\"></div>", startInd);
                if (startInd > -1)
                {
                    result = webResult.Substring(startInd, endInd - startInd);
                }
            }
            return result;
        }

        private void dgvTiketInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowsIndex = e.RowIndex;
            bookSelectedTiket(selectedRowsIndex);
        }

        private void bookSelectedTiket(int selectedRowsIndex)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                TicketInfo ticketInfo = dgvTiketInfo.Rows[selectedRowsIndex].DataBoundItem as TicketInfo;
                booking(ticketInfo);
                getVerificationCode();
                initDgvOrderSeatType(ticketInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void initDgvOrderSeatType(TicketInfo ticket)
        {
            DataGridViewComboBoxColumn dgvcbcSeatType;
            dgvcbcSeatType = dgvOrder.Columns["dgvcbcSeatType"] as DataGridViewComboBoxColumn;
            dgvcbcSeatType.DataSource = getSeatTypies(ticket);
        }

        private void getVerificationCode()
        {
            // 得到验证码
            try
            {
                picVerificationCode.Image = CommUitl.getVerificationCode("https://dynamic.12306.cn/otsweb/passCodeAction.do?rand=randp", CommData.cookieContainer, CommData.cookieCollection);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #region 得到旅客信息
        private List<Passenger> getPassenger(string webResult)
        {
            if (passengers == null)
            {
                passengers = new List<Passenger>();
                if (webResult.IndexOf("passengerJson") > -1)
                {
                    webResult = webResult.Split(new string[] { "passengerJson = " }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { "var ticketTypeReserveFlags" }, StringSplitOptions.RemoveEmptyEntries)[0];
                    webResult = CommUitl.ReplaceHTMLAttributes(webResult);
                    webResult = webResult.Replace("[", string.Empty);
                    webResult = webResult.Replace("]", string.Empty);
                    string[] strPasserngers = webResult.Split(new string[] { "},{" }, StringSplitOptions.RemoveEmptyEntries);
                    Passenger passenger;
                    string[] passengerProperties;
                    string strPassernger1;
                    foreach (var strPassernger in strPasserngers)
                    {
                        passenger = new Passenger();
                        strPassernger1 = strPassernger.Replace("\"", string.Empty);
                        passengerProperties = strPassernger1.Split(',');
                        passenger.MobileNo = passengerProperties[2].Split(':')[1];
                        passenger.CardNo = passengerProperties[6].Split(':')[1];
                        passenger.IDCardType = passengerProperties[7].Split(':')[1];
                        passenger.Name = passengerProperties[9].Split(':')[1];
                        passengers.Add(passenger);
                    }
                }
            }
            return passengers;
        }
        #endregion

        #region 增加旅客信息至界面
        private void initFlpPassenger()
        {
            Button btnLoadPassengers = new Button();
            btnLoadPassengers.Name = "btnLoadPassengers";
            btnLoadPassengers.Text = "加载乘客资料";
            btnLoadPassengers.AutoSize = true;
            btnLoadPassengers.Click += new EventHandler(btnLoadPassengers_Click);
            flpPassenger.Controls.Add(btnLoadPassengers);
        }

        void btnLoadPassengers_Click(object sender, EventArgs e)
        {
            if (dgvTiketInfo.SelectedCells.Count > 0)
            {
                bookSelectedTiket(dgvTiketInfo.SelectedCells[0].RowIndex);
            }
            else
            {
                MessageBox.Show("请选择需要乘坐的列车!");
            }
        }
        private void initFlpPassenger(List<Passenger> passengers)
        {
            Control control;
            for (int i = flpPassenger.Controls.Count-1; i >=0; i--)
            {
                control = flpPassenger.Controls[i];
                if (control is CheckBox || control.Name == "btnLoadPassengers")
                {
                    flpPassenger.Controls.Remove(control);
                }
            }
            foreach (var passenger in passengers)
            {
                CheckBox chkbox = new CheckBox();
                chkbox.Name = "chk" + passenger.CardNo;
                chkbox.Text = passenger.Name;
                chkbox.Tag = passenger;
                chkbox.AutoSize = true;
                chkbox.CheckedChanged += new EventHandler(chkbox_CheckedChanged);
                flpPassenger.Controls.Add(chkbox);
            }
        }

        void chkbox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkbox = sender as CheckBox;
            Passenger passenger = chkbox.Tag as Passenger;
            if (chkbox.Checked == true)
            {
                ordersPassengers.Add(passenger);
                //Orders.Passengers.Add(passenger);
            }
            else
            {
                ordersPassengers.Remove(passenger);
                //Orders.Passengers.Remove(passenger);
            }
        }
        #endregion

        private void btnSubmitOrder_Click(object sender, EventArgs e)
        {
            List<Passenger> passengers = getPassenger();
            Orders.Passengers = passengers;
            Orders.TicketInfo = dgvTiketInfo.Rows[dgvTiketInfo.SelectedCells[0].RowIndex].DataBoundItem as TicketInfo;
            Orders.Token = Token;
            Token = string.Empty;
            Orders.TrainDate = dtpDepartureDate.Value.ToString("yyyy-MM-dd");
            try
            {
                string webResult = submitOrder(Orders, txtVerificationCode.Text);
                string message = getMessage(webResult);
                if (string.IsNullOrEmpty(message) == false)
                {
                    MessageBox.Show(message);
                }
                else if (webResult.IndexOf("席位已成功锁定")>-1)
                {
                    MessageBox.Show("恭喜，您预订的席位已成功锁定!请在新开启的IE浏览器中进行支付!","恭喜",  MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    openIE();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void openIE()
        {
            foreach (Cookie cookie in CommData.cookieContainer.GetCookies(new Uri("https://dynamic.12306.cn/otsweb/loginAction.do?method=login")))
            {
                InternetSetCookie(
                    "https://" + cookie.Domain.ToString(),
                    cookie.Name.ToString(),
                    cookie.Value.ToString() + ";expires=Sun,22-Feb-2099 00:00:00 GMT");
            }
            string url="https://dynamic.12306.cn/otsweb/";
            System.Diagnostics.Process.Start("IExplore.exe", url); 
        }

        private List<Passenger> getPassenger()
        {
            List<Passenger> result=new List<Passenger>();
            //CheckBox checkBox;
            //foreach (var item in flpPassenger.Controls)
            //{
            //    if (item is CheckBox)
            //    {
            //        checkBox = item as CheckBox;
            //        if (checkBox.Checked == true)
            //        {
            //            result.Add(checkBox.Tag as Passenger);
            //        }
            //    }
            //}
            foreach (var passenger in ordersPassengers)
            {
                result.Add(passenger);
            }
            return result;
        }

        private string Token
        {
            get
            {
                if (string.IsNullOrEmpty(token) == true)
                {
                    token=getToken(CommUitl.getString(submutOrderRequestUrl, CommData.cookieContainer));
                    Debug.Write("Token:" + token);
                }
                return token;
            }
            set
            {
                token = value;
            }
        }

        /// <summary>
        /// 提交订单
        /// </summary>
        /// <param name="order"></param>
        /// <param name="randCode"></param>
        private string submitOrder(OrderInfo order, string randCode)
        {
            string result=string.Empty;
            string url = "https://dynamic.12306.cn/otsweb/order/confirmPassengerAction.do?method=confirmPassengerInfoSingle";
            List<KeyValuePair<string, string>> postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string,string>("org.apache.struts.taglib.html.TOKEN", order.Token));
            postData.Add(new KeyValuePair<string,string>("textfield", "中文或拼音首字母"));
            postData.Add(new KeyValuePair<string,string>("checkbox0", "0"));
            postData.Add(new KeyValuePair<string,string>("orderRequest.train_date", order.TrainDate));
            postData.Add(new KeyValuePair<string,string>("orderRequest.train_no", order.TicketInfo.TrainNo));
            postData.Add(new KeyValuePair<string,string>("orderRequest.station_train_code", order.TicketInfo.StationTrainCode));
            postData.Add(new KeyValuePair<string,string>("orderRequest.from_station_telecode", order.TicketInfo.DepartureStationTelCode));
            postData.Add(new KeyValuePair<string,string>("orderRequest.to_station_telecode", order.TicketInfo.DestinationStationTelCode));
            postData.Add(new KeyValuePair<string,string>("orderRequest.seat_type_code", ""));
            postData.Add(new KeyValuePair<string,string>("orderRequest.ticket_type_order_num", ""));
            postData.Add(new KeyValuePair<string,string>("orderRequest.bed_level_order_num", "000000000000000000000000000000"));
            postData.Add(new KeyValuePair<string,string>("orderRequest.start_time", order.TicketInfo.DrivingTime));
            postData.Add(new KeyValuePair<string,string>("orderRequest.end_time", order.TicketInfo.ArrivalTime));
            postData.Add(new KeyValuePair<string,string>("orderRequest.from_station_name", order.TicketInfo.DepartureStation));
            postData.Add(new KeyValuePair<string,string>("orderRequest.to_station_name", order.TicketInfo.DestinationStation));
            postData.Add(new KeyValuePair<string,string>("orderRequest.cancel_flag", "1"));
            postData.Add(new KeyValuePair<string,string>("orderRequest.id_mode", "Y"));
            Passenger passenger;
            for (int i = 0; i < 5; i++)
            {
                passenger = null;
                if (i < order.Passengers.Count)
                {
                    passenger = order.Passengers[i];
                    postData.Add(new KeyValuePair<string,string>("passengerTickets", passenger.PassengerTickets));
                    postData.Add(new KeyValuePair<string,string>("oldPassengers", passenger.OldPassengers));
                    postData.Add(new KeyValuePair<string,string>("passenger_"+(i+1)+"_seat", passenger.SeatType));
                    postData.Add(new KeyValuePair<string,string>("passenger_"+(i+1)+"_ticket", passenger.PassengerTicket));
                    postData.Add(new KeyValuePair<string,string>("passenger_"+(i+1)+"_name",passenger.Name));
                    postData.Add(new KeyValuePair<string,string>("passenger_"+(i+1)+"_cardtype", passenger.IDCardType));
                    postData.Add(new KeyValuePair<string,string>("passenger_"+(i+1)+"_cardno", passenger.CardNo));
                    postData.Add(new KeyValuePair<string,string>("passenger_"+(i+1)+"_mobileno", passenger.MobileNo));
                    postData.Add(new KeyValuePair<string,string>("checkbox9", "Y"));
                }
                else
                {
                    postData.Add(new KeyValuePair<string,string>("oldPassengers", string.Empty));
                    postData.Add(new KeyValuePair<string,string>("checkbox9", "Y"));
                }
            }
            postData.Add(new KeyValuePair<string,string>("randCode", randCode));
            postData.Add(new KeyValuePair<string,string>("orderRequest.reserve_flag", "A"));

            result= CommUitl.postString(url, postData, null, null, Encoding.UTF8, CommData.cookieCollection, "https://dynamic.12306.cn/otsweb/order/querySingleAction.do?method=init");
            return result;
        }

        private void initDgvOrder()
        {
            dgvOrder.AutoGenerateColumns = false;

            DataGridViewLinkColumn dgvlcDelete = new DataGridViewLinkColumn();
            dgvlcDelete.UseColumnTextForLinkValue = true;
            dgvlcDelete.Name = "dgvlcDelete";
            dgvlcDelete.Text = "删除";
            dgvlcDelete.HeaderText = string.Empty;
            dgvlcDelete.Width = 100;

            DataGridViewComboBoxColumn dgvcbcSeatType = new DataGridViewComboBoxColumn();
            dgvcbcSeatType.Name = "dgvcbcSeatType";
            dgvcbcSeatType.DataPropertyName = "SeatType";
            dgvcbcSeatType.DataSource = getSeatTypies();
            dgvcbcSeatType.ValueMember = "key";
            dgvcbcSeatType.DisplayMember = "value";
            dgvcbcSeatType.HeaderText = "席别";
            dgvcbcSeatType.Width = 100;

            DataGridViewComboBoxColumn dgvcbcPassengerTicket = new DataGridViewComboBoxColumn();
            dgvcbcPassengerTicket.Name = "dgvcbcPassengerTicket";
            dgvcbcPassengerTicket.DataPropertyName = "PassengerTicket";
            dgvcbcPassengerTicket.DataSource = getPassengerTickets();
            dgvcbcPassengerTicket.ValueMember = "key";
            dgvcbcPassengerTicket.DisplayMember = "value";
            dgvcbcPassengerTicket.HeaderText = "票种";
            dgvcbcPassengerTicket.Width = 100;

            DataGridViewTextBoxColumn dgvtbcName = new DataGridViewTextBoxColumn();
            dgvtbcName.Name = "dgvtbcName";
            dgvtbcName.DataPropertyName = "Name";
            dgvtbcName.HeaderText = "姓名";
            dgvtbcName.Width = 70;

            DataGridViewComboBoxColumn dgvcbcIDCardType = new DataGridViewComboBoxColumn();
            dgvcbcIDCardType.Name = "dgvcbcIDCardType";
            dgvcbcIDCardType.DataPropertyName = "IDCardType";
            dgvcbcIDCardType.DataSource = getIDCardTypies();
            dgvcbcIDCardType.ValueMember = "key";
            dgvcbcIDCardType.DisplayMember = "value";
            dgvcbcIDCardType.HeaderText = "证件类型";
            dgvcbcIDCardType.Width = 120;

            DataGridViewTextBoxColumn dgvtbcCardNo = new DataGridViewTextBoxColumn();
            dgvtbcCardNo.Name = "dgvtbcCardNo";
            dgvtbcCardNo.DataPropertyName = "CardNo";
            dgvtbcCardNo.HeaderText = "证件号码";
            dgvtbcCardNo.Width = 120;

            DataGridViewTextBoxColumn dgvtbcMobileNo = new DataGridViewTextBoxColumn();
            dgvtbcMobileNo.Name = "dgvtbcMobileNo";
            dgvtbcMobileNo.DataPropertyName = "MobileNo";
            dgvtbcMobileNo.HeaderText = "手机号";
            dgvtbcMobileNo.Width = 73;

            dgvOrder.Columns.Add(dgvlcDelete);
            dgvOrder.Columns.Add(dgvcbcSeatType);
            dgvOrder.Columns.Add(dgvcbcPassengerTicket);
            dgvOrder.Columns.Add(dgvtbcName);
            dgvOrder.Columns.Add(dgvcbcIDCardType);
            dgvOrder.Columns.Add(dgvtbcCardNo);
            dgvOrder.Columns.Add(dgvtbcMobileNo);

            dgvOrder.CellContentClick+=new DataGridViewCellEventHandler(dgvOrder_CellContentClick);
            dgvOrder.RowsAdded += new DataGridViewRowsAddedEventHandler(dgvOrder_RowsAdded);
            dgvOrder.RowsRemoved += new DataGridViewRowsRemovedEventHandler(dgvOrder_RowsRemoved);

            dgvOrder.DataSource = ordersPassengers;
        }

        void dgvOrder_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            autoChangeDgvOrderSize();
        }

        void dgvOrder_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            autoChangeDgvOrderSize();
        }

        void autoChangeDgvOrderSize()
        {
            tlpMain.RowStyles[5].Height = 28 * (dgvOrder.Rows.Count + 1);
        }

        private List<KeyValuePair<string, string>> getIDCardTypies()
        {
            List<KeyValuePair<string, string>> result;
            result = new List<KeyValuePair<string, string>>();
            result.Add(new KeyValuePair<string, string>("1", "二代身份证"));
            result.Add(new KeyValuePair<string, string>("2", "一代身份证"));
            result.Add(new KeyValuePair<string, string>("C", "港澳通行证"));
            result.Add(new KeyValuePair<string, string>("G", "台湾通行证"));
            result.Add(new KeyValuePair<string, string>("B", "护照"));

            return result;            
        }

        /// <summary>
        /// 乘客票类型 1 成人票 ;2 儿童票 ;3 学生票 ;4 残军票 
        /// </summary>
        /// <returns></returns>
        private List<KeyValuePair<string, string>> getPassengerTickets()
        {
            List<KeyValuePair<string, string>> result;
            result = new List<KeyValuePair<string, string>>();
            result.Add(new KeyValuePair<string, string>("1", "成人票"));
            result.Add(new KeyValuePair<string, string>("2", "儿童票"));
            result.Add(new KeyValuePair<string, string>("3", "学生票"));
            result.Add(new KeyValuePair<string, string>("4", "残军票"));
            return result;
        }

        /// <summary>
        /// 座位类型,1 硬座 ;3 硬卧;4 软卧 ;6 高级软卧;9 商务座  ;M 一等座 ;O 二等座 ;P 特等座
        /// </summary>
        /// <returns></returns>
        private List<KeyValuePair<string, string>> getSeatTypies()
        {
            List<KeyValuePair<string, string>> result;
            result = new List<KeyValuePair<string, string>>();
            result.Add(new KeyValuePair<string, string>("-1", "无座"));
            result.Add(new KeyValuePair<string, string>("1", "硬座"));
            result.Add(new KeyValuePair<string, string>("2", "软座"));
            result.Add(new KeyValuePair<string, string>("3", "硬卧"));
            result.Add(new KeyValuePair<string, string>("4", "软卧"));
            result.Add(new KeyValuePair<string, string>("6", "高级软卧"));
            result.Add(new KeyValuePair<string, string>("9", "商务座"));
            result.Add(new KeyValuePair<string, string>("M", "一等座"));
            result.Add(new KeyValuePair<string, string>("O", "二等座"));
            result.Add(new KeyValuePair<string, string>("P", "特等座"));
            return result;
        }

        /// <summary>
        /// 根据列车得到对应的座位信息
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        private List<KeyValuePair<string, string>> getSeatTypies(TicketInfo ticket)
        {
            List<KeyValuePair<string, string>> result;
            result = new List<KeyValuePair<string, string>>();
            foreach (var item in ticket.SeetInfos)
            {
                if (CommData.SeatTypeNo.ContainsKey(item.Key) == true && CommData.SeatTypeName.ContainsKey(item.Key) == true)
                {
                    if (item.Value > 0)
                    {
                        result.Add(new KeyValuePair<string, string>(CommData.SeatTypeNo[item.Key], CommData.SeatTypeName[item.Key]));
                    }
                }
            }
            return result;
        }

        void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                dgvOrder.Rows.RemoveAt(e.RowIndex);
            }
        }

        OrderInfo Orders
        {
            get
            {
                if (orders == null)
                {
                    orders = new OrderInfo();
                }
                return orders;
            }
            set
            {
                orders = value;
            }
        }

        private void picVerificationCode_Click(object sender, EventArgs e)
        {
            getVerificationCode();
        }

        private string getMessage(string webResult)
        {
            string result = string.Empty;
            string keyword="var message = \"";
            int startInt = webResult.IndexOf(keyword, 0);
            if (startInt > -1)
            {
                startInt += keyword.Length; ;
                int endInt = webResult.IndexOf("\";", startInt);
                result = webResult.Substring(startInt, endInt - startInt);
            }
            return result;
        }

    }
}
