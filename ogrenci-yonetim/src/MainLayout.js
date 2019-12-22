import React, { Component } from "react";
import TableContent from "./TableContent";
import TopMenu from "./TopMenu";
import { Container, Row, Col } from "reactstrap";
const menu = ["bir","Eğitim Bilgi Sistemi","Öğrenciler","Dersler"]
export default class MainLayout extends Component {

state = { tablo: [], whichTableIndex:"-1"};
  changeContextField =   (prmTblIndex) => {
    // console.log(prmContent);
    // console.log(this.state.tablo);
    this.setState({
      // tablo : prmContent,
      whichTableIndex:prmTblIndex
    });

    // console.log(this.state.tablo);
  };
  render() {
    return (
      <div>
        <div>

        {/* props ile calismalar */}
        {/* <Navi ornek ="Bu bir ornek navi yazidir"></Navi> */}
        {/*Props ve Encapsulations çalışmalar */}
        <TopMenu infoMenu={menu} onClickChange={this.changeContextField}></TopMenu>
        <Container>
          <Row xs="12">
            <Col xs="12">
              {/* props ile calismalar */}
              {/* <Context ornek = "bu bir Context ornek yazidir."></Context> */}
              {/*Props ve Encapsulations çalışmalar */}
              <TableContent  tableIndex={this.state.whichTableIndex}></TableContent>
             
            </Col>
            <Col xs="12">
             
            </Col>
          </Row>
        </Container>
      </div>
      </div>
    );
  }
}
