import React from 'react'
import { createRoot } from 'react-dom/client'
import './styles.css'

function App() {
  return (
    <main className="shell">
      <section className="hero">
        <p className="eyebrow">MSALAWI Platform</p>
        <h1>منصة مؤسسية للقطاع غير الربحي</h1>
        <p>
          Enterprise-grade foundation for governance, operations, people, finance,
          projects, and measurable impact.
        </p>
        <div className="status">v0.1.0-alpha · Foundation initialized</div>
      </section>
    </main>
  )
}

createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <App />
  </React.StrictMode>,
)
