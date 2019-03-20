using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nemo.GUI
{
    class Constants
    {
        public static string[] FilterSize = {	"Small (< 64Kb)", 
												"Medium (< 1Mb)", 
												"Large (< 10Mb)", 
												"Huge (> 10Mb)"};

        public static string[] FilterLength = {	"Short (< 1 min)", 
												"Medium (< 10 min)", 
												"Long (< 1 hour)", 
												"Extra (> 1 hour)"};
        public static int KB = 1024;
        public static int MB = 1048576; //1Mb
        public static int KB64 = 65536;
        public static int MB10 = MB * 10;

        public static TimeSpan MIN = new TimeSpan(0, 1, 0);
        public static TimeSpan MIN10 = new TimeSpan(0, 10, 0);
        public static TimeSpan HOUR = new TimeSpan(1, 0, 0);

        /*
         * [
Порт Описание Статус 
0/TCP,UDP Зарезервировано; не используется (но допустимо в качестве значения порта источника, если отправляющий процесс не ожидает ответных сообщений) Официально 
1/TCP,UDP TCPMUX, для обслуживания нескольких служб на одном и том же TCP порту Официально 
5/TCP,UDP протокол RJE (Remote Job Entry) — обслуживает отправку файлов и вывод отчётов при работе рабочей станции с мейнфреймами Официально 
7/TCP,UDP протокол ECHO — предназначен для тестирования связи путём отправки данных на сервер и получения от него их же в неизменном виде Официально 
9/TCP,UDP протокол DISCARD — предназначен для тестирования связи путём отправки данных на сервер, который отбрасывает принятое, не отправляя никакого ответа Официально 
11/TCP,UDP протокол SYSTAT — выдаёт список активных пользователей в операционной системе Официально 
13/TCP,UDP протокол DAYTIME — предназначен для тестирования связи путём получения от сервера текущих даты и времени в текстовом виде Официально 
15/TCP,UDP протокол NETSTAT Неодобрено 
17/TCP,UDP протокол QOTD (Quote of the Day) Официально 
18/TCP,UDP протокол MSP (Message Send Protocol) Официально 
19/TCP,UDP протокол CHARGEN (Character Generator) Официально 
20/TCP протокол FTP — данные Официально 
21/TCP протокол FTP — команды Официально 
22/TCP,UDP протокол SSH (Secure SHell) — применяется для безопасного входа в систему, file transfers (scp, sftp) and port forwarding Официально 
23/TCP,UDP протокол Telnet — применяется для незашифрованной символьной передачи Официально 
25/TCP,UDP протокол SMTP (Simple Mail Transfer Protocol) — используется для пересылки почтовых сообщений между серверами Официально 
26/TCP,UDP протокол RSFTP — простой аналог протокола FTP Неофициально 
35/TCP,UDP Any private printer server protocol Официально 
35/TCP,UDP QMS Magicolor 2 printer server protocol Неофициально 
37/TCP,UDP TIME protocol Официально 
39/TCP,UDP Resource Location Protocol[1] (RLP)—used for determining the location of higher level services from hosts on a network Официально 
41/TCP,UDP Graphics Официально 
42/TCP,UDP nameserver, ARPA Host Name Server Protocol Официально 
42/TCP,UDP WINS Неофициально 
43/TCP WHOIS protocol Официально 
49/TCP,UDP TACACS Login Host protocol Официально 
52/TCP,UDP XNS (Xerox Network Services) Time Protocol Официально 
53/TCP,UDP Domain Name System (DNS) Официально 
54/TCP,UDP XNS (Xerox Network Services) Clearinghouse Официально 
56/TCP,UDP XNS (Xerox Network Services) Authentication Официально 
56/TCP,UDP RAP (Route Access Protocol)[2] Неофициально 
57/TCP MTP, Mail Transfer Protocol Неофициально 
58/TCP,UDP XNS (Xerox Network Services) Mail Официально 
67/UDP Bootstrap Protocol (BOOTP) Server; also used by Dynamic Host Configuration Protocol (DHCP) Официально 
68/UDP Bootstrap Protocol (BOOTP) Client; also used by Dynamic Host Configuration Protocol (DHCP) Официально 
69/UDP Trivial File Transfer Protocol (TFTP) Официально 
70/TCP Gopher protocol Официально 
79/TCP Finger Официально 
80/TCP Hypertext Transfer Protocol (HTTP) Официально 
81/TCP Torpark—Onion routing Неофициально 
82/UDP Torpark—Control Неофициально 
83/TCP MIT ML Device Официально 
88/TCP Kerberos—authentication system Официально 
90/TCP,UDP dnsix (DoD Network Security for Information Exchange) Securit Attribute Token Map Официально 
90/TCP,UDP Pointcast Неофициально 
101/TCP NIC host name Официально 
102/TCP ISO-TSAP (Transport Service Access Point) Class 0 protocol[3] Официально 
107/TCP Remote TELNET Service[4] protocol Официально 
109/TCP Post Office Protocol 2 (POP2) Официально 
110/TCP Post Office Protocol 3 (POP3) Официально 
111/TCP,UDP Sun Remote Procedure Call Официально 
113/TCP ident—old user identification system, still used by IRC servers to identify users Официально 
113/TCP,UDP Authentication Service (auth) Официально 
115/TCP Simple File Transfer Protocol (SFTP) Официально 
117/TCP UUCP Path Service Официально 
118/TCP,UDP SQL (Structured Query Language) Services Официально 
119/TCP Network News Transfer Protocol (NNTP)—used for retrieving newsgroup messages Официально 
123/UDP Network Time Protocol (NTP)—used for time synchronization Официально 
135/TCP,UDP DCE endpoint resolution Официально 
135/TCP,UDP Microsoft EPMAP (End Point Mapper), also known as DCE/RPC Locator service[5], used to to remotely manage services including DHCP server, DNS server and WINS Неофициально 
137/TCP,UDP NetBIOS NetBIOS Name Service Официально 
138/TCP,UDP NetBIOS NetBIOS Datagram Service Официально 
139/TCP,UDP NetBIOS NetBIOS Session Service Официально 
143/TCP,UDP Internet Message Access Protocol (IMAP)—used for retrieving, organizing, and synchronizing e-mail messages Официально 
152/TCP,UDP Background File Transfer Program (BFTP)[6] Официально 
153/TCP,UDP SGMP, Simple Gateway Monitoring Protocol Официально 
156/TCP,UDP SQL Service Официально 
158/TCP,UDP DMSP, Distributed Mail Service Protocol Неофициально 
161/TCP,UDP Simple Network Management Protocol (SNMP) Официально 
162/TCP,UDP Simple Network Management Protocol Trap (SNMPTRAP)[7] Официально 
170/TCP Print-srv, Network PostScript Официально 
179/TCP BGP (Border Gateway Protocol) Официально 
194/TCP IRC (Internet Relay Chat) Официально 
201/TCP,UDP AppleTalk Routing Maintenance Официально 
209/TCP,UDP The Quick Mail Transfer Protocol Официально 
213/TCP,UDP IPX Официально 
218/TCP,UDP MPP, Message Posting Protocol Официально 
220/TCP,UDP IMAP, Interactive Mail Access Protocol, version 3 Официально 
259/TCP,UDP ESRO, Efficient Short Remote Operations Официально 
264/TCP,UDP BGMP, Border Gateway Multicast Protocol Официально 
311/TCP Mac OS X Server Admin (Официальноly AppleShare IP Web admistration) Официально 
308/TCP Novastor Online Backup Официально 
318/TCP,UDP PKIX TSP, Time Stamp Protocol Официально 
323/TCP,UDP IMMP, Internet Message Mapping Protocol Неофициально 
366/TCP,UDP ODMR, On-Demand Mail Relay Официально 
369/TCP,UDP Rpc2portmap Официально 
371/TCP,UDP ClearCase albd Официально 
383/TCP,UDP HP data alarm manager Официально 
384/TCP,UDP A Remote Network Server System Официально 
387/TCP,UDP AURP, AppleTalk Update-based Routing Protocol Официально 
389/TCP,UDP Lightweight Directory Access Protocol (LDAP) Официально 
401/TCP,UDP UPS Uninterruptible Power Supply Официально 
402/TCP Altiris, Altiris Deployment Client Неофициально 
411/TCP Direct Connect Hub Неофициально 
412/TCP Direct Connect Client-to-Client Неофициально 
427/TCP,UDP Service Location Protocol (SLP) Официально 
443/TCP Hypertext Transfer Protocol over TLS/SSL (HTTPS) Официально 
444/TCP,UDP SNPP, Simple Network Paging Protocol Официально 
445/TCP Microsoft-DS Active Directory, Windows shares Официально 
445/UDP Microsoft-DS SMB file sharing Официально 
464/TCP,UDP Kerberos Change/Set password Официально 
465/TCP Cisco protocol Неофициально 
465/TCP SMTP over SSL Неофициально 
475/TCP tcpnethaspsrv (Hasp services, TCP/IP version) Официально 
497/TCP Dantz Retrospect Официально 
500/UDP Internet Security Association and Key Management Protocol (ISAKMP) Официально 
502/TCP,UDP Modbus, Protocol Неофициально 
512/TCP exec, Remote Process Execution Официально 
512/UDP comsat, together with biff Официально 
513/TCP Login Официально 
513/UDP Who Официально 
514/TCP Shell—used to execute non-interactive commands on a remote system Официально 
514/UDP Syslog—used for system logging Официально 
515/TCP Line Printer Daemon—print service Официально 
517/UDP Talk Официально 
518/UDP NTalk Официально 
520/TCP efs, extended file name server Официально 
520/UDP Routing—RIP Официально 
524/TCP,UDP NCP (NetWare Core Protocol) is used for a variety things such as access to primary NetWare server resources, Time Synchronization, etc. Официально 
525/UDP Timed, Timeserver Официально 
530/TCP,UDP RPC Официально 
531/TCP,UDP AOL Instant Messenger, IRC Неофициально 
532/TCP netnews Официально 
533/UDP netwall, For Emergency Broadcasts Официально 
540/TCP UUCP (Unix-to-Unix Copy Protocol) Официально 
542/TCP,UDP commerce (Commerce Applications) Официально 
543/TCP klogin, Kerberos login Официально 
544/TCP kshell, Kerberos Remote shell Официально 
546/TCP,UDP DHCPv6 client Официально 
547/TCP,UDP DHCPv6 server Официально 
548/TCP Apple Filing Protocol (AFP) over TCP Официально 
550/UDP new-rwho, new-who Официально 
554/TCP,UDP Real Time Streaming Protocol (RTSP) Официально 
556/TCP Remotefs, RFS, rfs_server Официально 
560/UDP rmonitor, Remote Monitor Официально 
561/UDP monitor Официально 
563/TCP,UDP NNTP protocol over TLS/SSL (NNTPS) Официально 
587/TCP e-mail message submission[8] (SMTP) Официально 
591/TCP FileMaker 6.0 (and later) Web Sharing (HTTP Alternate, also see port 80) Официально 
593/TCP,UDP HTTP RPC Ep Map, Remote procedure call over Hypertext Transfer Protocol, often used by Distributed Component Object Model services and Microsoft Exchange Server Официально 
604/TCP TUNNEL profile[9], a protocol for BEEP peers to form an application layer tunnel Официально 
623/UDP ASF Remote Management and Control Protocol (ASF-RMCP) Официально 
631/TCP,UDP Internet Printing Protocol (IPP) Официально 
636/TCP,UDP Lightweight Directory Access Protocol over TLS/SSL (LDAPS) Официально 
639/TCP,UDP MSDP, Multicast Source Discovery Protocol Официально 
646/TCP LDP, Label Distribution Protocol, a routing protocol used in MPLS networks Официально 
647/TCP DHCP Failover protocol[10] Официально 
648/TCP RRP (Registry Registrar Protocol)[11] Официально 
652/TCP DTCP, Dynamic Tunnel Configuration Protocol Неофициально 
654/TCP AODV (Ad-hoc On-demand Distance Vector) Официально 
655/TCP IEEE MMS (IEEE Media Management System)[12][13] Официально 
657/TCP,UDP IBM RMC (Remote monitoring and Control) protocol, used by System p5 AIX Integrated Virtualization Manager (IVM)[14] and Hardware Management Console to connect managed logical partitions (LPAR) to enable dynamic partition reconfiguration Официально 
660/TCP Mac OS X Server administration Официально 
665/TCP sun-dr, Remote Dynamic Reconfiguration Неофициально 
666/UDP Doom, first online first-person shooter Официально 
674/TCP ACAP (Application Configuration Access Protocol) Официально 
691/TCP MS Exchange Routing Официально 
692/TCP Hyperwave-ISP Официально 
694/UDP Linux-HA High availability Heartbeat Неофициально 
695/TCP IEEE-MMS-SSL (IEEE Media Management System over SSL)[15] Официально 
698/UDP OLSR (Optimized Link State Routing) Официально 
699/TCP Access Network Официально 
700/TCP EPP (Extensible Provisioning Protocol), a protocol for communication between domain name registries and registrars Официально 
701/TCP LMP (Link Management Protocol (Internet))[16], a protocol that runs between a pair of nodes and is used to manage traffic engineering (TE) links Официально 
702/TCP IRIS[17][18] (Internet Registry Information Service) over BEEP (Blocks Extensible Exchange Protocol)[19] Официально 
706/TCP SILC, Secure Internet Live Conferencing Официально 
711/TCP Cisco TDP, Tag Distribution Protocol[20][21][22]—being replaced by the MPLS Label Distribution Protocol[23] Официально 
712/TCP TBRPF, Topology Broadcast based on Reverse-Path Forwarding routing protocol Официально 
712/UDP Promise RAID Controller Неофициально 
720/TCP SMQP, Simple Message Queue Protocol Неофициально 
749/TCP,UDP Kerberos administration Официально 
750/TCP rfile Официально 
750/UDP loadav Официально 
750/UDP kerberos-iv, Kerberos version IV Официально 
751/TCP,UDP pump Официально 
751/TCP,UDP kerberos_master, Kerberos authentication Неофициально 
752/TCP qrh Официально 
752/UDP qrh Официально 
752/UDP userreg_server, Kerberos Password (kpasswd) server Неофициально 
753/TCP Reverse Routing Header (rrh)[24] Официально 
753/UDP Reverse Routing Header (rrh) Официально 
753/UDP passwd_server, Kerberos userreg server Неофициально 
754/TCP tell send Официально 
754/TCP krb5_prop, Kerberos v5 slave propagation Неофициально 
754/UDP tell send Официально 
760/TCP,UDP ns Официально 
760/TCP,UDP krbupdate [kreg], Kerberos registration Неофициально 
782/TCP Conserver serial-console management server Неофициально 
829/TCP CMP (Certificate Management Protocol) Неофициально 
860/TCP iSCSI Официально 
873/TCP rsync file synchronisation protocol Официально 
888/TCP cddbp, CD DataBase (CDDB) protocol (CDDBP)—unassigned but widespread use Неофициально 
901/TCP Samba Web Administration Tool (SWAT) Неофициально 
902/TCP VMware Server Console[25] Неофициально 
904/TCP VMware Server Alternate (if 902 is in use, i.e. SUSE linux) Неофициально 
911/TCP Network Console on Acid (NCA)—local tty redirection over OpenSSH Неофициально 
981/TCP SofaWare Technologies Remote HTTPS management for firewall devices running embedded Check Point FireWall-1 software Неофициально 
989/TCP,UDP FTP Protocol (data) over TLS/SSL Официально 
990/TCP,UDP FTP Protocol (control) over TLS/SSL Официально 
991/TCP,UDP NAS (Netnews Administration System) Официально 
992/TCP,UDP TELNET protocol over TLS/SSL Официально 
993/TCP Internet Message Access Protocol over SSL (IMAPS) Официально 
995/TCP Post Office Protocol 3 over TLS/SSL (POP3S) Официально 
1023/TCP,UDP IANA Reserved Официально 




Port Description Status 
1024/TCP,UDP IANA Reserved Официально 
1025/TCP NFS-or-IIS Неофициально 
1026/TCP Often utilized by Microsoft DCOM services Неофициально 
1029/TCP Often utilized by Microsoft DCOM services Неофициально 
1085/TCP,UDP WebObjects Официально 
1058/TCP,UDP nim, IBM AIX Network Installation Manager (NIM) Официально 
1059/TCP,UDP nimreg, IBM AIX Network Installation Manager (NIM) Официально 
1080/TCP SOCKS proxy Официально 
1098/TCP,UDP rmiactivation, RMI Activation Официально 
1099/TCP,UDP rmiregistry, RMI Registry Официально 
1109 IANA Reserved Официально 
1109/TCP Kerberos Post Office Protocol (KPOP) Неофициально 
1140/TCP,UDP AutoNOC Network Operations protocol Официально 
1167/UDP phone, conference calling Неофициально 
1176/TCP Perceptive Automation Indigo Home automation server Официально 
1182/TCP,UDP AcceleNet Intelligent Transfer Protocol Официально 
1194/TCP,UDP OpenVPN Официально 
1198/TCP,UDP The cajo project Free dynamic transparent distributed computing in Java Официально 
1200/TCP scol, protocol used by SCOL 3D virtual worlds server to answer world name resolution client request[26] Официально 
1200/UDP scol, protocol used by SCOL 3D virtual worlds server to answer world name resolution client request Официально 
1200/UDP Steam Friends Applet Неофициально 
1214/TCP Kazaa Официально 
1220/TCP QuickTime Streaming Server administration Официально 
1223/TCP,UDP TGP, TrulyGlobal Protocol, also known as «The Gur Protocol» (named for Gur Kimchi of TrulyGlobal) Официально 
1241/TCP,UDP Nessus Security Scanner Официально 
1248/TCP NSClient/NSClient++/NC_Net (Nagios) Неофициально 
1270/TCP,UDP Microsoft System Center Operations Manager (SCOM) (formerly Microsoft Operations Manager (MOM)) agent Официально 
1311/TCP Dell Open Manage Https Неофициально 
1313/TCP Xbiim (Canvii server) Неофициально 
1337/TCP WASTE Encrypted File Sharing Program Неофициально 
1352/TCP IBM Lotus Notes/Domino Remote Procedure Call (RPC) protocol Официально 
1387/TCP,UDP cadsi-lm, LMS International (formerly Computer Aided Design Software, Inc. (CADSI)) LM Официально 
1414/TCP IBM WebSphere MQ (formerly known as MQSeries) Официально 
1431/TCP Reverse Gossip Transport Protocol (RGTP), used to access a General-purpose Reverse-Ordered Gossip Gathering System (GROGGS) bulletin board, such as that implemented on the Cambridge University's Phoenix system Официально 
1433/TCP,UDP СУБД Microsoft SQL Server — Server Официально 
1434/TCP,UDP СУБД Microsoft SQL Server — Monitor Официально 
1494/TCP Citrix XenApp Independent Computing Architecture (ICA) thin client protocol Официально 
1512/TCP,UDP Microsoft Windows Internet Name Service (WINS) Официально 
1521/TCP nCube License Manager Официально 
1521/TCP Oracle database default listener, in future releases Официально port 2483 Неофициально 
1524/TCP,UDP ingreslock, ingres Официально 
1526/TCP Oracle database common alternative for listener Неофициально 
1533/TCP IBM Sametime IM—Virtual Places Chat Официально 
1547/TCP,UDP Laplink Официально 
1550 Gadu-Gadu (direct client-to-client) Неофициально 
1581/UDP MIL STD 2045-47001 VMF Официально 
1589/UDP Cisco VQP (VLAN Query Protocol) / VMPS Неофициально 
1645/TCP,UDP radius, RADIUS authentication protocol (default for Cisco and Juniper Networks RADIUS servers) Неофициально 
1646/TCP,UDP radacct, RADIUS accounting protocol (default for Cisco and Juniper Networks RADIUS servers) Неофициально 
1627 iSketch Неофициально 
1677/TCP,UDP Novell GroupWise clients in client/server access mode Официально 
1701/UDP Layer 2 Forwarding Protocol (L2F) & Layer 2 Tunneling Protocol (L2TP) Официально 
1716/TCP America's Army Massively multiplayer online role-playing game (MMORPG) Неофициально 
1723/TCP,UDP Microsoft Point-to-Point Tunneling Protocol (PPTP) Официально 
1725/UDP Valve Steam Client Неофициально 
1755/TCP,UDP Microsoft Media Services (MMS, ms-streaming) Официально 
1761/TCP,UDP cft-0 Официально 
1761/TCP Novell Zenworks Remote Control utility Неофициально 
1762—1768/TCP,UDP cft-1 to cft-7 Официально 
1812/TCP,UDP radius, RADIUS authentication protocol Официально 
1813/TCP,UDP radacct, RADIUS accounting protocol Официально 
1863/TCP MSNP (Microsoft Notification Protocol), used by the .NET Messenger Service and a number of Instant Messaging clients Официально 
1900/UDP Microsoft SSDP Enables discovery of UPnP devices Официально 
1935/TCP Adobe Macromedia Flash Real Time Messaging Protocol (RTMP) «plain» protocol Официально 
1970/TCP,UDP Danware NetOp Remote Control Официально 
1971/TCP,UDP Danware NetOp School Официально 
1972/TCP,UDP InterSystems Caché Официально 
1975—1977/UDP Cisco TCO (Documentation) Официально 
1984/TCP Big Brother—network monitoring tool Официально 
1985/UDP Cisco HSRP Официально 
1994/TCP,UDP Cisco STUN-SDLC (Serial Tunneling—Synchronous Data Link Control) protocol Официально 
1998/TCP,UDP Cisco X.25 over TCP (XOT) service Официально 
2000/TCP,UDP Cisco SCCP (Skinny) Официально 
2002/TCP Secure Access Control Server (ACS) for Windows Неофициально 
2030 Oracle Services for Microsoft Transaction Server Неофициально 
2031/TCP,UDP mobrien-chat—obsolete (ex-http://www.mobrien.com) Официально 
2049/UDP Network File System Официально 
2049/UDP shilp Официально 
2053/UDP lot105-ds-upd Lot105 DSuper Updates Официально 
2053/TCP lot105-ds-upd Lot105 DSuper Updates Официально 
2053/TCP knetd Kerberos de-multiplexor Неофициально 
2056/UDP Civilization 4 multiplayer Неофициально 
2073/TCP,UDP DataReel Database Официально 
2074/TCP,UDP Vertel VMF SA (i.e. App.. SpeakFreely) Официально 
2082/TCP Infowave Mobility Server Официально 
2082/TCP CPanel default Неофициально 
2083/TCP Secure Radius Service (radsec) Официально 
2083/TCP CPanel default SSL Неофициально 
2086/TCP GNUnet Официально 
2086/TCP WebHost Manager default Неофициально 
2087/TCP WebHost Manager default SSL Неофициально 
2095/TCP CPanel default Web mail Неофициально 
2096/TCP CPanel default SSL Web mail Неофициально 
2102/TCP,UDP zephyr-srv Project Athena Zephyr Notification Service server Официально 
2103/TCP,UDP zephyr-clt Project Athena Zephyr Notification Service serv-hm connection Официально 
2104/TCP,UDP zephyr-hm Project Athena Zephyr Notification Service hostmanager Официально 
2105/TCP,UDP IBM MiniPay Официально 
2105/TCP,UDP eklogin Kerberos encrypted remote login (rlogin) Неофициально 
2105/TCP,UDP zephyr-hm-srv Project Athena Zephyr Notification Service hm-serv connection (should use port 2102) Неофициально 
2161/TCP APC Agent Официально 
2181/TCP,UDP EForward-document transport system Официально 
2190/UDP TiVoConnect Beacon Неофициально 
2200/UDP Tuxanci game server[27] Неофициально 
2219/TCP,UDP NetIQ NCAP Protocol Официально 
2220/TCP,UDP NetIQ End2End Официально 
2222/TCP DirectAdmin default Неофициально 
2222/UDP Microsoft Office OS X antipiracy network monitor [1] Неофициально 
2301/TCP HP System Management Redirect to port 2381 Неофициально 
2302/UDP ArmA multiplayer (default for game) Неофициально 
2302/UDP Halo: Combat Evolved multiplayer Неофициально 
2303/UDP ArmA multiplayer (default for server reporting) (default port for game +1) Неофициально 
2305/UDP ArmA multiplayer (default for VoN) (default port for game +3) Неофициально 
2369/TCP Default for BMC Software CONTROL-M/Server—Configuration Agent, though often changed during installation Неофициально 
2370/TCP Default for BMC Software CONTROL-M/Server—to allow the CONTROL-M/Enterprise Manager to connect to the CONTROL-M/Server, though often changed during installation Неофициально 
2381/TCP HP Insight Manager default for Web server Неофициально 
2404/TCP IEC 60870-5-104, used to send electric power telecontrol messages between two systems via directly connected data circuits Официально 
2427/UDP Cisco MGCP Официально 
2447/TCP,UDP ovwdb—OpenView Network Node Manager (NNM) daemon Официально 
2483/TCP,UDP Oracle database listening for unsecure client connections to the listener, replaces port 1521 Официально 
2484/TCP,UDP Oracle database listening for SSL client connections to the listener Официально 
2546/TCP,UDP Vytal Vault—Data Protection Services Неофициально 
2593/TCP,UDP RunUO—Ultima Online server Неофициально 
2598/TCP new ICA—when Session Reliability is enabled, TCP port 2598 replaces port 1494 Неофициально 
2612/TCP,UDP QPasa from MQSoftware Официально 
2710/TCP XBT Bittorrent Tracker Неофициально 
2710/UDP XBT Bittorrent Tracker experimental UDP tracker extension Неофициально 
2710/TCP Knuddels.de Неофициально 
2735/TCP,UDP NetIQ Monitor Console Официально 
2809/TCP corbaloc:iiop URL, per the CORBA 3.0.3 specification Официально 
2809/TCP IBM WebSphere Application Server (WAS) Bootstrap/rmi default Неофициально 
2809/UDP corbaloc:iiop URL, per the CORBA 3.0.3 specification. Официально 
2944/UDP Megaco Text H.248 Неофициально 
2945/UDP Megaco Binary (ASN.1) H.248 Неофициально 
2948/TCP,UDP WAP-push Multimedia Messaging Service (MMS) Официально 
2949/TCP,UDP WAP-pushsecure Multimedia Messaging Service (MMS) Официально 
2967/TCP Symantec AntiVirus Corporate Edition Неофициально 
3000/TCP Miralix License server Неофициально 
3000/UDP Distributed Interactive Simulation (DIS), modifiable default Неофициально 
3001/TCP Miralix Phone Monitor Неофициально 
3002/TCP Miralix CSTA Неофициально 
3003/TCP Miralix GreenBox API Неофициально 
3004/TCP Miralix InfoLink Неофициально 
3006/TCP Miralix SMS Client Connector Неофициально 
3007/TCP Miralix OM Server Неофициально 
3025/TCP netpd.org Неофициально 
3030/TCP NetPanzer Неофициально 
3030/UDP NetPanzer Неофициально 
3050/TCP,UDP gds_db (Interbase/Firebird) Официально 
3074/TCP,UDP Xbox Live Официально 
3128/TCP HTTP used by Web caches and the default for the Squid cache & Kerio Winroute Firewall Неофициально 
3260/TCP,UDP iSCSI target Официально 
3268/TCP,UDP msft-gc, Microsoft Global Catalog (LDAP service which contains data from Active Directory forests) Официально 
3269/TCP,UDP msft-gc-ssl, Microsoft Global Catalog over SSL (similar to port 3268, LDAP over SSL) Официально 
3283/TCP Apple Remote Desktop reporting (Официальноly Net Assistant, referring to an earlier product) Официально 
3300/TCP TripleA game server Неофициально 
3305/TCP,UDP odette-ftp, Odette File Transfer Protocol (OFTP) Официально 
3306/TCP,UDP MySQL database system Официально 
3333/TCP Network Caller ID server Неофициально 
3386/TCP,UDP GTP' 3GPP GSM/UMTS CDR logging protocol Официально 
3389/TCP Microsoft Terminal Server (RDP) Официальноly registered as Windows Based Terminal (WBT) Неофициально 
3396/TCP,UDP Novell NDPS Printer Agent Официально 
3455/TCP,UDP [RSVP] Reservation Protocol Официально 
3632/TCP distributed compiler Официально 
3689/TCP Digital Audio Access Protocol (DAAP)—used by Apple’s iTunes and AirPort Express Официально 
3690/TCP,UDP Subversion version control system Официально 
3702/TCP,UDP Web Services Dynamic Discovery (WS-Discovery), used by various components of Windows Vista Официально 
3724/TCP,UDP World of Warcraft Online gaming MMORPG Официально 
3784/TCP,UDP Ventrilo VoIP program used by Ventrilo Неофициально 
3785/UDP Ventrilo VoIP program used by Ventrilo Неофициально 
3868/TCP Diameter base protocol Официально 
3872/TCP Oracle Management Remote Agent Неофициально 
3899/TCP Remote Administrator Неофициально 
3900/TCP udt_os, IBM UniData UDT OS[28] Официально 
3945/TCP,UDP EMCADS service, a Giritech product used by G/On Официально 
4000/TCP,UDP Diablo II game Неофициально 
4007/TCP PrintBuzzer printer monitoring socket server Неофициально 
4089/TCP,UDP OpenCORE Remote Control Service Официально 
4093/TCP,UDP PxPlus Client server interface ProvideX Официально 
4096/TCP,UDP Bridge-Relay Element ASCOM Официально 
4100 WatchGuard Authentication Applet—default Неофициально 
4111/TCP Xgrid Официально 
4111/TCP Microsoft Office SharePoint Portal Server administration Неофициально 
4125/TCP Microsoft Remote Web Workplace administration Неофициально 
4226/TCP,UDP Aleph One (game) Неофициально 
4224/TCP Cisco CDP Cisco discovery Protocol Неофициально 
4500/UDP IPsec NAT traversal Официально 
4569/UDP Inter-Asterisk eXchange Неофициально 
4662/TCP,UDP OrbitNet Message Service Официально 
4662/TCP often used by eMule Неофициально 
4664/TCP Google Desktop Search Неофициально 
4672/UDP eMule—often used Неофициально 
4747/TCP Apprentice Неофициально 
4750/TCP BladeLogic Agent Неофициально 
4894/TCP,UDP LysKOM Protocol A Официально 
4899/TCP,UDP Radmin remote administration tool (program sometimes used as a Trojan horse) Официально 
5000/TCP commplex-main Официально 
5000/TCP UPnP—Windows network device interoperability Неофициально 
5000/TCP,UDP VTun—VPN Software Неофициально 
5001/TCP commplex-link Официально 
5001/TCP,UDP Iperf (Tool for measuring TCP and UDP bandwidth performance) Неофициально 
5001/TCP Slingbox and Slingplayer Неофициально 
5003/TCP,UDP FileMaker Официально 
5004/TCP,UDP RTP (Real-time Transport Protocol) media data Официально 
5005/TCP,UDP RTP (Real-time Transport Protocol) control protocol Официально 
5031/TCP,UDP AVM CAPI-over-TCP (ISDN over Ethernet tunneling) Неофициально 
5050/TCP Yahoo! Messenger Неофициально 
5051/TCP ita-agent Symantec Intruder Alert[29] Официально 
5060/TCP,UDP Session Initiation Protocol (SIP) Официально 
5061/TCP Session Initiation Protocol (SIP) over TLS Официально 
5093/UDP SPSS (Statistical Package for the Social Sciences) License Administrator Неофициально 
5104/TCP IBM Tivoli Framework NetCOOL/Impact[30] HTTP Service Неофициально 
5106/TCP A-Talk Common connection Неофициально 
5107/TCP A-Talk Remote server connection Неофициально 
5110/TCP ProRat Server Неофициально 
5121/TCP Neverwinter Nights Неофициально 
5154/TCP,UDP BZFlag Официально 
5176/TCP ConsoleWorks default UI interface Неофициально 
5190/TCP ICQ and AOL Instant Messenger Официально 
5222/TCP Extensible Messaging and Presence Protocol (XMPP, Jabber) client connection Официально 
5223/TCP Extensible Messaging and Presence Protocol (XMPP, Jabber) client connection over SSL Неофициально 
5269/TCP Extensible Messaging and Presence Protocol (XMPP, Jabber) server connection Официально 
5298/TCP,UDP Extensible Messaging and Presence Protocol (XMPP) link-local messaging Официально 
5351/TCP,UDP NAT Port Mapping Protocol—client-requested configuration for inbound connections through network address translators Официально 
5353/UDP Multicast DNS (MDNS) Официально 
5355/TCP,UDP LLMNR—Link-Local Multicast Name Resolution, allows hosts to perform name resolution for hosts on the same local link (only provided by Windows Vista and Server 2008) Официально 
5402/TCP,UDP mftp, Stratacache OmniCast content delivery system MFTP file sharing protocol Официально 
5405/TCP,UDP NetSupport Официально 
5421/TCP,UDP Net Support 2 Официально 
5432/TCP,UDP PostgreSQL database system Официально 
5445/UDP Cisco Unified Video Advantage Неофициально 
5495/TCP Applix TM1 Admin server Неофициально 
5498/TCP Hotline tracker server connection Неофициально 
5499/UDP Hotline tracker server discovery Неофициально 
5500/TCP VNC remote desktop protocol—for incoming listening viewer, Hotline control connection Неофициально 
5501/TCP Hotline file transfer connection Неофициально 
5517/TCP Setiqueue Proxy server client for SETI@Home project Неофициально 
5555/TCP Freeciv versions up to 2.0, Hewlett Packard Data Protector, SAP Неофициально 
5556/TCP,UDP Freeciv Официально 
5631/TCP pcANYWHEREdata, Symantec pcAnywhere (version 7.52 and later[31])[32] data Официально 
5632/UDP pcANYWHEREstat, Symantec pcAnywhere (version 7.52 and later) status Официально 
5666/TCP NRPE (Nagios) Неофициально 
5667/TCP NSCA (Nagios) Неофициально 
5800/TCP VNC remote desktop protocol—for use over HTTP Неофициально 
5814/TCP,UDP Hewlett-Packard Support Automation (HP OpenView Self-Healing Services) Официально 
5900/TCP,UDP Virtual Network Computing (VNC) remote desktop protocol (used by Apple Remote Desktop and others) Официально 
5938/TCP,UDP TeamViewer[33] remote desktop protocol Неофициально 
5984/TCP,UDP CouchDB database server Официально 
6000/TCP X11—used between an X client and server over the network Официально 
6001/UDP X11—used between an X client and server over the network Официально 
6005/TCP Default for BMC Software CONTROL-M/Server—Socket used for communication between CONTROL-M processes—though often changed during installation Неофициально 
6050/TCP Brightstor Arcserve Backup Неофициально 
6051/TCP Brightstor Arcserve Backup Неофициально 
6086/TCP PDTP—FTP like file server in a P2P network Официально 
6100/TCP Vizrt System Неофициально 
6110/TCP,UDP softcm, HP Softbench CM Официально 
6111/TCP,UDP spc, HP Softbench Sub-Process Control Официально 
6112/TCP,UDP «dtspcd»—a network daemon that accepts requests from clients to execute commands and launch applications remotely Официально 
6112/TCP Blizzard's Battle.net gaming service, ArenaNet gaming service Неофициально 
6129/TCP Dameware Remote Control Неофициально 
6257/UDP WinMX (see also 6699) Неофициально 
6346/TCP,UDP gnutella-svc, Gnutella (FrostWire, Limewire, Shareaza, etc.) Официально 
6347/TCP,UDP gnutella-rtr, Gnutella alternate Официально 
6444/TCP,UDP Sun Grid Engine—Qmaster Service Официально 
6445/TCP,UDP Sun Grid Engine—Execution Service Официально 
6502/TCP,UDP Danware Data NetOp Remote Control Неофициально 
6522/TCP Gobby (and other libobby-based software) Неофициально 
6543/UDP Paradigm Research & Development Jetnet[34] default Неофициально 
6566/TCP SANE (Scanner Access Now Easy)—SANE network scanner daemon Неофициально 
6600/TCP Music Playing Daemon (MPD) Неофициально 
6619/TCP,UDP odette-ftps, Odette File Transfer Protocol (OFTP) over TLS/SSL Официально 
6665-6669/TCP Internet Relay Chat Официально 
6679/TCP IRC SSL (Secure Internet Relay Chat)—often used Неофициально 
6697/TCP IRC SSL (Secure Internet Relay Chat)—often used Неофициально 
6699/TCP WinMX (see also 6257) Неофициально 
6771/UDP Polycom server broadcast Неофициально 
6881-6887/TCP,UDP BitTorrent part of full range of ports used most often Неофициально 
6888/TCP,UDP MUSE Официально 
6888/TCP,UDP BitTorrent part of full range of ports used most often Неофициально 
6889-6890/TCP,UDP BitTorrent part of full range of ports used most often Неофициально 
6891-6900/TCP,UDP BitTorrent part of full range of ports used most often Неофициально 
6891-6900/TCP,UDP Windows Live Messenger (File transfer) Неофициально 
6901/TCP,UDP Windows Live Messenger (Voice) Неофициально 
6901/TCP,UDP BitTorrent part of full range of ports used most often Неофициально 
6902-6968/TCP,UDP BitTorrent part of full range of ports used most often Неофициально 
6969/TCP,UDP acmsoda Официально 
6969/TCP BitTorrent tracker Неофициально 
6970-6999/TCP,UDP BitTorrent part of full range of ports used most often Неофициально 
7000/TCP Default for Azureus's built in HTTPS Bittorrent Tracker Неофициально 
7001/TCP Default for BEA WebLogic Server's HTTP server, though often changed during installation Неофициально 
7002/TCP Default for BEA WebLogic Server's HTTPS server, though often changed during installation Неофициально 
7005/TCP,UDP Default for BMC Software CONTROL-M/Server and CONTROL-M/Agent—Agent-to-Server, though often changed during installation Неофициально 
7006/TCP,UDP Default for BMC Software CONTROL-M/Server and CONTROL-M/Agent—Server-to-Agent, though often changed during installation Неофициально 
7010/TCP Default for Cisco AON AMC (AON Management Console) [2] Неофициально 
7025/TCP Zimbra LMTP [mailbox]—local mail delivery Неофициально 
7047/TCP Zimbra conversion server Неофициально 
7133/TCP Enemy Territory: Quake Wars Неофициально 
7171/TCP Tibia Неофициально 
7306/TCP Zimbra mysql [mailbox] Неофициально 
7307/TCP Zimbra mysql [logger] Неофициально 
7312/UDP Sibelius License Server Неофициально 
7670/TCP BrettspielWelt BSW Boardgame Portal Неофициально 
7777/TCP iChat server file transfer proxy Неофициально 
7777/TCP Default used by Windows backdoor program tini.exe Неофициально 
7831/TCP Default used by Smartlaunch Internet Cafe Administration[35] software Неофициально 
8000/TCP,UDP iRDMI (Intel Remote Desktop Management Interface)[36]—sometimes erroneously used instead of port 8080 Официально 
8000/TCP Commonly used for internet radio streams such as those using SHOUTcast Неофициально 
8002/TCP Cisco Systems Unified Call Manager Intercluster Неофициально 
8008/TCP HTTP Alternate Официально 
8008/TCP IBM HTTP Server administration default Неофициально 
8010/TCP XMPP/Jabber File transfers Неофициально 
8074/TCP Gadu-Gadu Неофициально 
8080/TCP HTTP alternate (http_alt)—commonly used for Web proxy and caching server, or for running a Web server as a non-root user Официально 
8080/TCP Apache Tomcat Неофициально 
8086/TCP HELM Web Host Automation Windows Control Panel Неофициально 
8086/TCP Kaspersky AV Control Center Неофициально 
8087/TCP Hosting Accelerator Control Panel Неофициально 
8087/UDP Kaspersky AV Control Center Неофициально 
8090/TCP Another HTTP Alternate (http_alt_alt)—used as an alternative to port 8080 Неофициально 
8118/TCP Privoxy—advertisement-filtering Web proxy Официально 
8087/TCP SW Soft Plesk Control Panel Неофициально 
8200/TCP GoToMyPC Неофициально 
8220/TCP Bloomberg Неофициально 
8222 VMware Server Management User Interface (insecure Web interface)[37]. See also port 8333 Неофициально 
8291/TCP Winbox—Default on a MikroTik RouterOS for a Windows application used to administer MikroTik RouterOS Неофициально 
8294/TCP Bloomberg Неофициально 
8333 VMware Server Management User Interface (secure Web interface)[38]. See also port 8222 Неофициально 
8400/TCP,UDP cvp, Commvault Unified Data Management Официально 
8443/TCP SW Soft Plesk Control Panel Неофициально 
8500/TCP ColdFusion Macromedia/Adobe ColdFusion default Неофициально 
8501/UDP Duke Nukem 3D—default Неофициально 
8767/UDP TeamSpeak—default Неофициально 
8880/UDP cddbp-alt, CD DataBase (CDDB) protocol (CDDBP) alternate Официально 
8880/TCP cddbp-alt, CD DataBase (CDDB) protocol (CDDBP) alternate Официально 
8880/TCP WebSphere Application Server SOAP connector default Неофициально 
8881/TCP Atlasz Informatics Research Ltd Secure Application Server Неофициально 
8882/TCP Atlasz Informatics Research Ltd Secure Application Server Неофициально 
8888/TCP,UDP NewsEDGE server Официально 
8888/TCP Sun Answerbook dwhttpd server (deprecated by docs.sun.com) Неофициально 
8888/TCP GNUmp3d HTTP music streaming and Web interface Неофициально 
8888/TCP LoLo Catcher HTTP Web interface (www.optiform.com) Неофициально 
9000/TCP Buffalo LinkSystem Web access Неофициально 
9000/TCP DBGp Неофициально 
9000/UDP UDPCast Неофициально 
9001 cisco-xremote router configuration Неофициально 
9001 Tor network default Неофициально 
9001/TCP DBGp Proxy Неофициально 
9009/TCP,UDP Pichat Server—Peer to peer chat software Официально 
9043/TCP WebSphere Application Server Administration Console secure Неофициально 
9060/TCP WebSphere Application Server Administration Console Неофициально 
9080/UDP glrpc, Groove Collaboration software GLRPC Официально 
9080/TCP glrpc, Groove Collaboration software GLRPC Официально 
9080/TCP WebSphere Application Server Http Transport (port 1) default Неофициально 
9090/TCP Openfire Administration Console Неофициально 
9100/TCP Jetdirect HP Print Services Официально 
9110/UDP SSMP Message protocol Неофициально 
9101 Bacula Director Официально 
9102 Bacula File Daemon Официально 
9103 Bacula Storage Daemon Официально 
9119/TCP,UDP MXit Instant Messenger Официально 
9418/TCP,UDP git, Git pack transfer service Официально 
9535/TCP mngsuite, LANDesk Management Suite Remote Control Официально 
9535/TCP BBOS001, IBM Websphere Application Server (WAS) High Avail Mgr Com Неофициально 
9443/TCP WebSphere Application Server Http Transport (port 2) default Неофициально 
9535/UDP mngsuite, LANDesk Management Suite Remote Control Официально 
9800/TCP,UDP WebDAV Source Официально 
9800 WebCT e-learning portal Неофициально 
9999 Hydranode—edonkey2000 TELNET control Неофициально 
9999/TCP Lantronix UDS-10/UDS100[39] RS-485 to Ethernet Converter TELNET control Неофициально 
9999 Urchin Web Analytics Неофициально 
10000 Webmin—Web-based Linux admin tool Неофициально 
10000 BackupExec Неофициально 
10001/TCP Lantronix UDS-10/UDS100[40] RS-485 to Ethernet Converter default Неофициально 
10008/TCP,UDP Octopus Multiplexer, primary port for the CROMP protocol, which provides a platform-independent means for communication of objects across a network Официально 
10017 AIX,NeXT, HPUX—rexd daemon control Неофициально 
10024/TCP Zimbra smtp [mta]—to amavis from postfix Неофициально 
10025/TCP Ximbra smtp [mta]—back to postfix from amavis Неофициально 
10050/TCP,UDP Zabbix-Agent Официально 
10051/TCP,UDP Zabbix-Trapper Официально 
10113/TCP,UDP NetIQ Endpoint Официально 
10114/TCP,UDP NetIQ Qcheck Официально 
10115/TCP,UDP NetIQEndpoint Официально 
10116/TCP,UDP NetIQ VoIP Assessor Официально 
10200/TCP FRISK Software International's fpscand virus scanning daemon for Unix platforms [3] Неофициально 
10200-10204/TCP FRISK Software International's f-protd virus scanning daemon for Unix platforms [4] Неофициально 
10308 Lock-on: Modarn Air Combat Неофициально 
10480 SWAT 4 Dedicated Server Неофициально 
11211 memcached Неофициально 
11235 Savage:Battle for Newerth Server Hosting Неофициально 
11294 Blood Quest Online Server Неофициально 
11371 OpenPGP HTTP Keyserver Официально 
11576 IPStor Server management communication Неофициально 
12035/UDP Linden Lab viewer to sim Неофициально 
12345 NetBus—remote administration tool (often Trojan horse). Also used by NetBuster. Little Fighter 2 (TCP). Неофициально 
12975/TCP LogMeIn Hamachi (VPN tunnel software; also port 32976)—used to connect to Mediation Server (bibi.hamachi.cc); will attempt to use SSL (TCP port 443) if both 12975 & 32976 fail to connect Неофициально 
13000-13050/UDP Linden Lab viewer to sim Неофициально 
13720/TCP,UDP Symantec NetBackup—bprd (formerly VERITAS) Официально 
13721/TCP,UDP Symantec NetBackup—bpdbm (formerly VERITAS) Официально 
13724/TCP,UDP Symantec Network Utility—vnetd (formerly VERITAS) Официально 
13782/TCP,UDP Symantec NetBackup—bpcd (formerly VERITAS) Официально 
13783/TCP,UDP Symantec VOPIED protocol (formerly VERITAS) Официально 
13785/TCP,UDP Symantec NetBackup Database—nbdb (formerly VERITAS) Официально 
13786/TCP,UDP Symantec nomdb (formerly VERITAS) Официально 
14567/UDP Battlefield 1942 and mods Неофициально 
15000/TCP psyBNC Неофициально 
15000/TCP Wesnoth Неофициально 
15000/TCP hydap, Hypack Hydrographic Software Packages Data Acquisition Официально 
15000/UDP hydap, Hypack Hydrographic Software Packages Data Acquisition Официально 
15567/UDP Battlefield Vietnam and mods Неофициально 
15345/TCP,UDP XPilot Contact Официально 
16000/TCP shroudBNC Неофициально 
16080/TCP Mac OS X Server Web (HTTP) service with performance cache[41] Неофициально 
16384/UDP Iron Mountain Digital online backup Неофициально 
16567/UDP Battlefield 2 and mods Неофициально 
19226/TCP Panda Software AdminSecure Communication Agent Неофициально 
19638/TCP Ensim Control Panel Неофициально 
19813/TCP 4D database Client Server Communication Неофициально 
20000 DNP (Distributed Network Protocol), a protocol used in SCADA systems between communicating RTU's and IED's Официально 
20000 Usermin, Web-based user tool Неофициально 
20720/TCP Symantec i3 Web GUI server Неофициально 
22004/TCP,UDP Порт сервера MTA Deathmatch Неофициально 
22347/TCP,UDP WibuKey, WIBU-SYSTEMS AG Software protection system Официально 
22350/TCP,UDP CodeMeter, WIBU-SYSTEMS AG Software protection system Официально 
24554/TCP,UDP BINKP, Fidonet mail transfers over TCP/IP Официально 
24800 Synergy: keyboard/mouse sharing software Неофициально 
24842 StepMania: Online: Dance Dance Revolution Simulator Неофициально 
25999/TCP Xfire Неофициально 
26000/TCP,UDP id Software's Quake server Официально 
26000/TCP CCP's EVE Online Online gaming MMORPG Неофициально 
27000/UDP (through 27006) id Software's QuakeWorld master server Неофициально 
27010 Half-Life and its mods, such as Counter-Strike Неофициально 
27015 Half-Life and its mods, such as Counter-Strike Неофициально 
27374 Sub7 default. Most script kiddies do not change from this. Неофициально 
27500/UDP (through 27900) id Software's QuakeWorld Неофициально 
27888/UDP Kaillera server Неофициально 
27900 (through 27901) Nintendo Wi-Fi Connection Неофициально 
27901/UDP (through 27910) id Software's Quake II master server Неофициально 
27960/UDP (through 27969) Activision's Enemy Territory and id Software's Quake III Arena and Quake III and some ioquake3 derived games Неофициально 
28910 Nintendo Wi-Fi Connection Неофициально 
28960 Call of Duty 2 Common Call of Duty 2 (PC Version) Неофициально 
28961 Call of Duty 4: Modern Warfare Common Call of Duty 4 (PC Version) Неофициально 
29900 (through 29901) Nintendo Wi-Fi Connection Неофициально 
29920 Nintendo Wi-Fi Connection Неофициально 
30000 Pokemon Netbattle Неофициально 
30564/TCP Multiplicity: keyboard/mouse/clipboard sharing software Неофициально 
31337/TCP Back Orifice—remote administration tool (often Trojan horse) Неофициально 
31337/TCP xc0r3 security Неофициально 
31415 ThoughtSignal—Server Communication Service (often Informational) Неофициально 
31456-31458/TCP TetriNET (in order: IRC, game, and spectating) Неофициально 
32245/TCP MMTSG-mutualed over MMT (encrypted transmission) Неофициально 
32976/TCP LogMeIn Hamachi (VPN tunnel software; also port 12975)—used to connect to Mediation Server (bibi.hamachi.cc); will attempt to use SSL (TCP port 443) if both 12975 & 32976 fail to connect Неофициально 
33434/TCP,UDP traceroute Официально 
34443 Linksys PSUS4 print server Неофициально 
37777/TCP Digital Video Recorder hardware Неофициально 
36963 Counter Strike 2D multiplayer (2D clone of popular CounterStrike computer game) Неофициально 
40000/TCP,UDP SafetyNET p Real-time Industrial Ethernet protocol Официально 
43594-43595/TCP RuneScape Неофициально 
47808/TCP,UDP BACnet Building Automation and Control Networks Официально 
49151 IANA Reserved Официально 

3306/TCP,UDP — MS SQL зачастую конфликтует с MySQL из-за портов
3307/TCP,UDP — MySQL (возможно выбирать до 3309, рекомендуется любой кроме 3306, из-за конфликта с MS SQL)

2992\UDP - AstralMasters the game www.astralmasters.com

         */
        public static Dictionary<uint, string> GetDefaultServiceMap()
        {
            Dictionary<uint, string> serv = new Dictionary<uint, string>();
            serv.Add(5, "RJE");
            serv.Add(7, "ECHO");
            serv.Add(9, "DISCARD");
            serv.Add(11, "SYSTAT");
            serv.Add(13, "DAYTIME");
            serv.Add(15, "NETSTAT");
            serv.Add(17, "QOTD");
            serv.Add(18, "MSP");
            serv.Add(19, "CHARGEN");
            serv.Add(21, "FTP");
            serv.Add(20, "FTP");
            serv.Add(22, "SSH");
            serv.Add(23, "Telnet");
            serv.Add(25, "SMTP");
            serv.Add(37, "Time");
            serv.Add(43, "WHOIS");
            serv.Add(49, "TACACS");
            serv.Add(53, "DNS");
            serv.Add(67, "BOOTP");
            serv.Add(68, "BOOTP");
            serv.Add(69, "TFTP");
            serv.Add(70, "Gopher");
            serv.Add(79, "Finger");
            serv.Add(80, "HTTP");
            serv.Add(88, "Kerberos");
            serv.Add(109, "POP2");
            serv.Add(110, "POP3");
            serv.Add(111, "SunRPC");
            serv.Add(113, "ident");
            serv.Add(117, "UUCP");
            serv.Add(118, "SQL");
            serv.Add(119, "NNTP");
            serv.Add(123, "NTP");
            serv.Add(137, "NetBIOS");
            serv.Add(138, "NetBIOS");
            serv.Add(139, "NetBIOS");
            serv.Add(143, "IMAP");
            serv.Add(153, "SGMP");
            serv.Add(156, "SQL");
            serv.Add(161, "SNMP");
            serv.Add(162, "SNMPTrap");
            serv.Add(170, "PostScript");
            serv.Add(179, "BGP");
            serv.Add(194, "IRC");
            serv.Add(213, "IPX");
            serv.Add(218, "MPP");
            serv.Add(220, "IMAP3");
            serv.Add(259, "ESRO");
            serv.Add(264, "BGMP");
            serv.Add(311, "MacOS X Server Admin");
            serv.Add(318, "PKIX TSP");
            serv.Add(323, "IMMP");
            serv.Add(366, "OMDR");
            serv.Add(369, "Rpc2portmap");
            serv.Add(371, "ClearCase albd");
            serv.Add(383, "HP data alarm manager");
            serv.Add(387, "AURP");
            serv.Add(389, "LDAP");
            serv.Add(401, "UPS");
            serv.Add(411, "DC Hub");
            serv.Add(412, "DC Client-to-Client");
            serv.Add(427, "SLP");
            serv.Add(443, "HTTPS");
            serv.Add(444, "SNPP");
            serv.Add(475, "tcpnethaspsrv");
            serv.Add(512, "exec");
            serv.Add(5060, "SIP");
            serv.Add(5061, "SIP");
            serv.Add(5190, "ICQ");
            return serv;
        }
    }
}
