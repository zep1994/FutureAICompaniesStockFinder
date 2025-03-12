import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Home from "./pages/Home";
import Category from "./pages/Category";
import ToolDetail from "./pages/ToolDetail";
import Navbar from "./components/Navbar";
import Footer from "./components/Footer";
import "./styles/global.css";

function App() {
  return (
    <Router>
      <Navbar />
      <main className="container">
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/category/:name" element={<Category />} />
          <Route path="/tool/:id" element={<ToolDetail />} />
        </Routes>
      </main>
      <Footer />
    </Router>
  );
}

export default App;
