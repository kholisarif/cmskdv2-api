using AutoMapper;
using ICMSTU.API.Commands.Golongan;
using ICMSTU.API.Commands.Menu;
using ICMSTU.API.Commands.Role;
using ICMSTU.API.Commands.UnitOrganisasi;
using ICMSTU.API.Commands.User;
using ICMSTU.API.Commands.UserRole;
using ICMSTU.API.Commands.Bank;
using ICMSTU.API.Commands.BPK;
using ICMSTU.API.Commands.BEND;
using ICMSTU.API.Commands.DAFTUNIT;
using ICMSTU.API.Commands.DAFTPHK;
using ICMSTU.API.Commands.KEGUNIT;
using ICMSTU.API.Commands.BPKDETR;
using ICMSTU.API.Commands.BPKDETRDANA;
using ICMSTU.API.Commands.MKegiatan;
using ICMSTU.API.Commands.MPGRM;
using ICMSTU.API.Commands.Pegawai;
using ICMSTU.API.Commands.PGRMUNIT;
using ICMSTU.API.Commands.MATANGR;
using ICMSTU.API.Commands.JBAYAR;
using ICMSTU.API.Commands.JTRANSFER;
using ICMSTU.API.Commands.JDANA;
using ICMSTU.API.Commands.Berita;
using ICMSTU.API.Commands.BERITADETR;
using ICMSTU.API.Commands.SP2D;
using ICMSTU.API.Commands.DASKR;
using ICMSTU.API.Commands.Kontrak;
using ICMSTU.API.Commands.SBDANAR;
using ICMSTU.API.Commands.NPD;
using ICMSTU.API.Commands.NPDBPK;
using ICMSTU.API.Commands.NPDSTS;
using ICMSTU.API.Commands.NPDTBPL;
using ICMSTU.API.Commands.STATTRS;
using ICMSTU.API.Commands.JCAIR;
using ICMSTU.API.Commands.JKIRIM;
using ICMSTU.API.Commands.JTRNLKAS;
using ICMSTU.API.Dtos;
using ICMSTU.API.Helpers;
using ICMSTU.API.Models.Entities;

namespace ICMSTU.API.Infrastructures
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<UnitOrganisasiCreate, UnitOrganisasi>();

      CreateMap<UserCreate, User>()
        .ForMember(d => d.Password, opt => opt.MapFrom(s => PasswordHasher.Create(s.Password)))
        .ForMember(d => d.Username, opt => opt.MapFrom(s => s.Username.ToLower()));

      CreateMap<UserUpdate, User>()
        .ForMember(d => d.Password, opt => opt.MapFrom(s => PasswordHasher.Create(s.NewPassword)));
      CreateMap<User, UserDto>();

      CreateMap<GolonganCreate, Golongan>();
      CreateMap<GolonganUpdate, Golongan>();

      CreateMap<MenuCreateCommand, Menu>();
      CreateMap<MenuUpdateCommand, Menu>();

      CreateMap<RoleCreate, Role>()
        .ForMember(d => d.Nama, opt => opt.MapFrom(s => s.Nama.ToLower()));
      CreateMap<RoleUpdate, Role>()
        .ForMember(d => d.Nama, opt => opt.MapFrom(s => s.Nama.ToLower()));

      CreateMap<UserRole, UserRoleDto>();
      CreateMap<UserRoleCreate, UserRole>();

      CreateMap<BankCreate, Bank>();
      CreateMap<BankUpdate, Bank>();

      CreateMap<BPKCreate, BPK>();
      CreateMap<BPKUpdate, BPK>();

      CreateMap<BENDCreate, BEND>();
      CreateMap<BENDUpdate, BEND>();

      CreateMap<DAFTUNITCreate, DAFTUNIT>();
      CreateMap<DAFTUNITUpdate, DAFTUNIT>();

      CreateMap<DAFTPHKCreate, DAFTPHK>();
      CreateMap<DAFTPHKUpdate, DAFTPHK>();

      CreateMap<KEGUNITCreate, KEGUNIT>();
      CreateMap<KEGUNITUpdate, KEGUNIT>();

      CreateMap<BPKDETRCreate, BPKDETR>();
      CreateMap<BPKDETRUpdate, BPKDETR>();

      CreateMap<BPKDETRDANACreate, BPKDETRDANA>();
      CreateMap<BPKDETRDANAUpdate, BPKDETRDANA>();

      CreateMap<MKegiatanCreate, MKegiatan>();
      CreateMap<MKegiatanUpdate, MKegiatan>();

      CreateMap<MPGRMCreate, MPGRM>();
      CreateMap<MPGRMUpdate, MPGRM>();

      CreateMap<PegawaiCreate, Pegawai>();
      CreateMap<PegawaiUpdate, Pegawai>();

      CreateMap<PGRMUNITCreate, PGRMUNIT>();
      CreateMap<PGRMUNITUpdate, PGRMUNIT>();

      CreateMap<MATANGRCreate, MATANGR>();
      CreateMap<MATANGRUpdate, MATANGR>();

      CreateMap<JBAYARCreate, JBAYAR>();
      CreateMap<JBAYARUpdate, JBAYAR>();

      CreateMap<JTRANSFERCreate, JTRANSFER>();
      CreateMap<JTRANSFERUpdate, JTRANSFER>();

      CreateMap<JDANACreate, JDANA>();
      CreateMap<JDANAUpdate, JDANA>();

      CreateMap<BeritaCreate, Berita>();
      CreateMap<BeritaUpdate, Berita>();

      CreateMap<BERITADETRCreate, BERITADETR>();
      CreateMap<BERITADETRUpdate, BERITADETR>();

      CreateMap<SP2DCreate, SP2D>();
      CreateMap<SP2DUpdate, SP2D>();

      CreateMap<DASKRCreate, DASKR>();
      CreateMap<DASKRUpdate, DASKR>();

      CreateMap<KontrakCreate, Kontrak>();
      CreateMap<KontrakUpdate, Kontrak>();

      CreateMap<SBDANARCreate, SBDANAR>();
      CreateMap<SBDANARUpdate, SBDANAR>();

      CreateMap<NPDCreate, NPD>();
      CreateMap<NPDUpdate, NPD>();

      CreateMap<NPDBPKCreate, NPDBPK>();
      CreateMap<NPDBPKUpdate, NPDBPK>();

      CreateMap<NPDSTSCreate, NPDSTS>();
      CreateMap<NPDSTSUpdate, NPDSTS>();

      CreateMap<NPDTBPLCreate, NPDTBPL>();
      CreateMap<NPDTBPLUpdate, NPDTBPL>();

      CreateMap<STATTRSCreate, STATTRS>();
      CreateMap<STATTRSUpdate, STATTRS>();

      CreateMap<JCAIRCreate, JCAIR>();
      CreateMap<JCAIRUpdate, JCAIR>();

      CreateMap<JKIRIMCreate, JKIRIM>();
      CreateMap<JKIRIMUpdate, JKIRIM>();

      CreateMap<JTRNLKASCreate, JTRNLKAS>();
      CreateMap<JTRNLKASUpdate, JTRNLKAS>();
    }
  }
}
